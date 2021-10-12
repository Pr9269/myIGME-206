using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE15
{
    public interface ICustomer
    {
        void Greet();
    }

    public class Customer : ICustomer
    {
        public string name;
        private string creditCardNumber;
        public string CreditCardNumber
        {
            set
            {
                this.creditCardNumber = value;
            }
        }

        public void Greet()
        {
            Console.WriteLine("Hello!");
        }
    }

    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string brand;
        public string size;

        public Customer customer;

        public HotDrink()
        {
            this.instant = false;
            this.milk = false;
            this.sugar = 0;
            this.size = "medium";

            this.customer = new Customer();
        }

        public HotDrink(string brand)
        {
            // Folgers is instant coffee
            if (brand == "Folgers")
            {
                this.instant = true;
            }

            this.brand = brand;

            this.customer = new Customer();
        }

        public virtual void AddSugar(byte amount)
        {
            sugar += amount;
        }

        public abstract void Steam();
    }

    public class CupOfCoffee : HotDrink
    {
        public string beanType;

        public CupOfCoffee()
        {

        }

        public CupOfCoffee(string brand) : base(brand)
        {
            if (brand == "Folgers")
            {
                this.beanType = "rancid";
            }
        }

        public override void Steam()
        {
        }
    }

}
