using System;
using System.Windows.Markup;
using static System.Math;

namespace _35_2_Filipenko_Problem1.NeuroNet
{
    class Neiron
    {
        private NeuronType type;//тип нейрона
        private double[] _weights;//его веса
        private double[] _inputs;//его входы
        private double _output;//его выход
        private double _derivative;//производная функции активации гипербтангенс-даня
        private double a = 0.01;//константы для функции активации гипербтангенс-я
        //входной 2 скрытых выходной    
        //15 70 32 10 verbitskyy
        //15 70 36 10 kazakov
        //15 71 31 10 maga
        //15 71 33 10 filipenko
        public double[] Weights { get => _weights; set => _weights = value; }
        public double[] Inputs
        {
            get { return _inputs; }
            set { _inputs = value; }
        }
        public double Output { get => _output; }
        public double Derivative { get => _derivative; }

        //конструктор
        public Neiron(double[] weights, NeuronType type)
        {
            this.type = type;
            _weights = weights;
        }

        

        public void Activator(double[] i, double[] w) //нелинейные преобразования
        {
            double sum = w[0]; //
            for (int m = 0; m < i.Length; m++)
                sum += i[m] * w[m + 1]; //линейные преобразования
            
            
            switch (type)
            {
                case NeuronType.Hidden:
                    _output = HyperbolicTan(sum);
                    _derivative = HyperbolicTan_Derivator(sum);
                    break;
                case NeuronType.Output:
                    _output=Exp(sum);
                    break;
            }
        }



        private double HyperbolicTan(double sum)
        {
            return (Exp(sum) - Exp(-sum)) / (Exp(sum) + Exp(-sum));
        }
        private double HyperbolicTan_Derivator(double sum)
        {
            return 1-HyperbolicTan(sum)*HyperbolicTan(sum);
        }
       

    }
}
