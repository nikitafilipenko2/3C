using System;


namespace _35_2_Filipenko_Problem1.NeuroNet
{
    class NetWork
    {
        private InputLayer input_layer=null;
        private HiddenLayer hidden_layer1 = new HiddenLayer(71, 15, NeuronType.Hidden, nameof(hidden_layer1));
        private HiddenLayer hidden_layer2 = new HiddenLayer(33, 71, NeuronType.Hidden, nameof(hidden_layer2));
        private OutputLayer output_layer = new OutputLayer(10, 33, NeuronType.Output, nameof(output_layer));

        public double[] fact=new double[10];

        private double[] e_error_avr;
        public double[] E_error_avr { get => e_error_avr; set => e_error_avr = value; }

        public NetWork() { }

        public void Train(NetWork net)
        {
            int epoches = 100;
            net.input_layer = new InputLayer(NetworkMode.Train);
            double tmpSumError;
            double[] errors;
            double[] temp_grsums1;
            double[] temp_grsums2;

            e_error_avr=new double[epoches];

            for (int k = 0; k < epoches; k++)//perebor epoch obucheniya
            {
                e_error_avr[k] = 0;
                for (int i = 0; i < net.input_layer.Trainset.GetLength(0); i++)
                {
                    double[] tmpTrain = new double[15];
                    for (int j=0;j<tmpTrain.Length; j++)
                    {
                        tmpTrain[j]=net.input_layer.Trainset[i,j+1];
                    }
                    ForwardPass(net,tmpTrain);
                    tmpSumError = 0;
                    errors=new double[net.fact.Length];
                    for (int x = 0; x < errors.Length; x++)
                    {
                        if (x == net.input_layer.Trainset[i,0])
                            errors[x]=net.fact[x]-1;
                        else errors[x]=0;
                        tmpSumError+= errors[x]*errors[x]/2;

                    }
                    e_error_avr[k] += tmpSumError/errors.Length;
                    temp_grsums2 = net.output_layer.BackwardPass(errors);
                    temp_grsums1 = net.hidden_layer2.BackwardPass(temp_grsums2);
                    net.hidden_layer1.BackwardPass(temp_grsums1);

                }
                e_error_avr[k] /=net.input_layer.Trainset.GetLength(0);
            }
            net.input_layer = null;//какое то обчение и что то считывалось

            net.hidden_layer1.WeightInitialize(MemoryMode.SET, AppDomain.CurrentDomain.BaseDirectory + "memory\\" + "hidden_layer1_memory.csv");
            net.hidden_layer2.WeightInitialize(MemoryMode.SET, AppDomain.CurrentDomain.BaseDirectory + "memory\\" + "hidden_layer2_memory.csv");
            net.output_layer.WeightInitialize(MemoryMode.SET, AppDomain.CurrentDomain.BaseDirectory + "memory\\" + "output_layer_memory.csv");



        }

        public void ForwardPass(NetWork net, double[] netInput)
        {
            net.hidden_layer1.Data=netInput;
            net.hidden_layer1.Recognize(null,net.hidden_layer2);
            net.hidden_layer2.Recognize(null,net.output_layer);
            net.output_layer.Recognize(net, null);
        }
    }
}
