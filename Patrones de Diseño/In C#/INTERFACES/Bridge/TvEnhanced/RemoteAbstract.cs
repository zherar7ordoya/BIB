namespace TvEnhanced
{
    public abstract class RemoteAbstract
    {
        protected ITV implementor;

        protected RemoteAbstract(ITV implementor)
        {
            this.implementor = implementor;
        }

        public abstract void SwitchOn();
        public abstract void SwitchOff();
        public abstract void SetChannel(int channel);
    }
}
