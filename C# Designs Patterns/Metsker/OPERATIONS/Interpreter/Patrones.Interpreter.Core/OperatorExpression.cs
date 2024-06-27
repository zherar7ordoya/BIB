
namespace Interpreter
{
    public class OperatorExpression : IExpression
    {
        private string _operation;

        public OperatorExpression(string token)
        {
            _operation = token;
        }

        public void interpret(Context context)
        {
            context.EstablecerOperacion(_operation);
        }
    }
}