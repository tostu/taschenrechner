using System;
namespace Taschenrechner
{
    public class Calculation
    {
    
        private decimal value, operand2, operand1= 0;
        
        public enum Method
        {
            NotSet,
            Add,
            Substract,
            Multiply,
            Divide
        }
        public Method method;


        public void reset()
        {
            this.operand2 = 0;
            this.operand1 = 0;
            this.value = 0;
        }


        public void setOperand1(String inputString)
        {
            this.operand1 = convertToDecimal(inputString);
        }

        public void setOperand2(String inputString)
        {
            this.operand2 = convertToDecimal(inputString);
        }

        public String getVal()
        {
            return this.value.ToString();
        }

        public void calculate()
        {
            switch (this.method)
            {
                case Method.Add:
                    {
                        this.add();
                        break;
                    }
                case Method.Substract:
                    {
                        this.substract();
                        break;
                    }
                case Method.Multiply:
                    {
                        this.multiply();
                        break;
                    }
                case Method.Divide:
                    {
                        this.divide();
                        break;
                    }
                default:
                    break;
            }

            this.operand1 = this.value;

        }

        private void add()
        {
            this.value = this.operand1 + this.operand2;
        }

        private void substract(){
            this.value = this.operand1 - this.operand2;
        }

        private void multiply()
        {
            this.value = this.operand1 * this.operand2;

        }

        private void divide()
        {
            this.value = this.operand1 / this.operand2;
        }

        private Decimal convertToDecimal(String inputString)
        {
            if (Decimal.TryParse(inputString, out decimal convertedString))
            {
                return convertedString;
            }
            else
            {
                return 0;
            }
        }



    }
}
