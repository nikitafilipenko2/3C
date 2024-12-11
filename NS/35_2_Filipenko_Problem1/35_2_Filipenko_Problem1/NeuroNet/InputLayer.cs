using System;
using System.CodeDom.Compiler;
using System.IO;

namespace _35_2_Filipenko_Problem1.NeuroNet
{
    internal class InputLayer { 
        private Random random = new Random();

        private double[,] trainset = new double[100, 16];
        private double[,] testset = new double[10, 16];
        public double[,] Trainset { get=>trainset;}
        public double[,] Testset { get=>testset;}
        public InputLayer(NetworkMode nm)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string[] tmpStr;
            string[] tmpArrStr;
            double[] tmpArr;
            switch (nm)
            {
                case NetworkMode.Train:
                    tmpArrStr = File.ReadAllLines(path+"train.txt");
                    for (int i = 0; i < tmpArrStr.Length; i++)
                    {
                        tmpStr = tmpArrStr[i].Split();
                        tmpArr=new double[tmpStr.Length];
                        for (int j=0;j< tmpArrStr.Length; j++)
                        {
                            tmpArr[j]=double.Parse(tmpStr[j],System.Globalization.CultureInfo.InvariantCulture);

                        }
                    }
                    for (int n = trainset.GetLength(0) - 1; n >= 1; n--)
                    {
                        double[] temp=new double[trainset.GetLength(1)];
                        int j=random.Next(n+1);
                        for (int i = 0; i < trainset.GetLength(1); i++)
                        {
                            
                            temp[i] = trainset[n,i];
                        }
                        for (int i = 0; i < Trainset.GetLength(1); i++)
                        {
                            trainset[n, i] = trainset[j,i];
                            trainset[j, i] = temp[i];
                        }
                    }
                    break;
                case NetworkMode.Test:
                    tmpArrStr = File.ReadAllLines(path + "test.txt");
                    for (int i = 0; i < tmpArrStr.Length; i++)
                    {
                        tmpStr = tmpArrStr[i].Split();
                        for (int j = 0; j < tmpStr.Length; j++)
                        {
                            testset[i, j] = double.Parse(tmpStr[j], System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    break;
                case NetworkMode.Recogn:
                    break;
            }
        }

    }
}
