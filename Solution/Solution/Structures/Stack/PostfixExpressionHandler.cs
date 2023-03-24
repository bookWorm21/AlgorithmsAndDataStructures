using System;
using System.Collections.Generic;
using System.Data;

namespace AlgorithmsDataStructures
{
    public class PostfixExpressionHandler
    {
        private static Dictionary<string, Operator> _operators = new Dictionary<string, Operator>
        {
            {"+", new PlusOperator()},
            {"-", new MinusOperator()},
            {"*", new MultiplicationOperator()},
            {"/", new DivisionOperator()},
            {"=", new EqualOperator()},
        };
        
        public static float Calculate(string expression)
        {
            var units = expression.Split(' ');
            var operands = new Stack<float>();

            foreach (var unit in units)
            {
                if (TryHandleOperation(unit, operands, out float operateResult))
                {
                    operands.Push(operateResult);
                    continue;
                }

                if (float.TryParse(unit, out float value))
                {
                    operands.Push(value);
                    continue;
                }

                throw new InvalidExpressionException("Invalid postfix expression");
            }

            var result = GetOneOperand(operands);
            return result;
        }
        
        private static float GetOneOperand(Stack<float> operandStack)
        {
            if (operandStack.Size() < 1)
            {
                throw new ArgumentException("Haven't one operand");
            }

            return operandStack.Pop();
        }

        private static bool TryHandleOperation(string operation, Stack<float> operands, out float result)
        {
            result = 0;
            if(!_operators.TryGetValue(operation, out Operator operat))
            {
                return false;
            }

            var args = new float[operat.OperandsCount];
            for (int i = 0; i < operat.OperandsCount; ++i)
            {
                args[i] = GetOneOperand(operands);
            }

            result = operat.Operate(args);
            return true;
        }

        private abstract class Operator
        {
            public abstract int OperandsCount { get; }

            public float Operate(params float[] args)
            {
                if (args.Length != OperandsCount)
                {
                    throw new ArgumentException("Wrong operands count");
                }

                return OperateInternal(args);
            }

            protected abstract float OperateInternal(params float[] args);
        }

        private sealed class PlusOperator : Operator
        {
            public override int OperandsCount => 2;

            protected override float OperateInternal(params float[] args)
            {
                return args[0] + args[1];
            }
        }

        private sealed class MinusOperator : Operator
        {
            public override int OperandsCount => 2;

            protected override float OperateInternal(params float[] args)
            {
                return args[1] - args[0];
            }
        }
        
        private sealed class MultiplicationOperator : Operator
        {
            public override int OperandsCount => 2;

            protected override float OperateInternal(params float[] args)
            {
                return args[0] * args[1];
            }
        }

        private sealed class DivisionOperator : Operator
        {
            public override int OperandsCount => 2;

            protected override float OperateInternal(params float[] args)
            {
                return args[1] / args[0];
            }
        }
        
        private sealed class EqualOperator : Operator
        {
            public override int OperandsCount => 1;
            
            protected override float OperateInternal(params float[] args)
            {
                return args[0];
            }
        }
    }
}