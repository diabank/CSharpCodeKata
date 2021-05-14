namespace ProviderQuality.Console.AwardObjects
{
    public class BlueDistinctionPlusAward : Award
    {
        public BlueDistinctionPlusAward(int expiresIn)
            : base("Blue Distinction Plus", expiresIn, 0)
        {
            //Enforcing Quality never change
            _quality = 80;
        }

        public override void ProcessUpdate() 
        {
            ProcessExpiredIn();
        }
    }
}
