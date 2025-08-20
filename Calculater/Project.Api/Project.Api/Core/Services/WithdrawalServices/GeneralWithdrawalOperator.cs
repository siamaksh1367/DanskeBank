namespace Project.Api.Core.Services.WithdrawalServices
{
    public abstract class GeneralWithdrawalOperator<T> : IWithdrawalOperator<T>
    {
        protected abstract int Value { get; }
        protected abstract short Location { get; }
        public virtual Withdrawal CalculateWithdrawal(int remaining)
        {
            if (Value == 0)
                throw new ArgumentException("Can not divide to zeor");

            return new Withdrawal() { Location = Location, Quantity = remaining / Value, Remaining = remaining % Value };
        }

        public int GetValue()
        {
            return Value;
        }
    }
}



