using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Задание__Паттерны_
{
    class Program
    {
        static void Main()
        {
            Sphere original = new Sphere(0, 0, 0, "Red");
            Sphere clone = (Sphere)original.Clone();

            clone.X = 10;
            clone.Color = "Blue";

            Console.WriteLine(original);
            Console.WriteLine(clone);

            CoffeeMachine machine = new CoffeeMachine();

            machine.InsertCoin();
            machine.SelectDrink();
            machine.DispenseDrink();

            IChatMediator mediator = new ChatMediator();

            IChatMember Antoxa = new ChatMember("Antoxa", mediator);
            IChatMember Sergey = new ChatMember("sergey", mediator);

            mediator.AddMember(Antoxa);
            mediator.AddMember(Sergey);

            Antoxa.Send("Привет, Serega");
            Sergey.Send("Antoxa, privet!!!");

            IOrder order = new BaseOrder();
            order = new FastDelivery(order);
            order = new GiftWrap(order);

            Console.WriteLine(order.GetDescription());
            Console.WriteLine(order.GetPrice());


            IService service = new ProxyService();

            Console.WriteLine(service.GetData());
            Console.WriteLine(service.GetData());
        }
    }



    interface ICloneable
    {
        ICloneable Clone();
    }

    class Sphere : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public string Color { get; set; }

        public Sphere(int x, int y, int z, string color)
        {
            X = x;
            Y = y;
            Z = z;
            Color = color;
        }

        public ICloneable Clone()
        {
            return new Sphere(X, Y, Z, Color);
        }

        public override string ToString()
        {
            return $"Sphere at ({X}, {Y}, {Z}) with color {Color}";
        }
    }


    interface ICoffeeMachineState
    {
        void InsertCoin();
        void SelectDrink();
        void DispenseDrink();
    }

    class WaitingState : ICoffeeMachineState
    {
        public void InsertCoin() => Console.WriteLine("Монета внесена. Выберите напиток");
        public void SelectDrink() => Console.WriteLine("Сначала внесите монету");
        public void DispenseDrink() => Console.WriteLine("Сначала внесите монету");
    }

    class DrinkSelectedState : ICoffeeMachineState
    {
        public void InsertCoin() => Console.WriteLine("Монета уже внесена");
        public void SelectDrink() => Console.WriteLine("Напиток уже выбран");
        public void DispenseDrink() => Console.WriteLine("Выдаём напток");
    }

    class CoffeeMachine
    {
        private ICoffeeMachineState _state;

        public CoffeeMachine()
        {
            _state = new WaitingState();
        }

        public void SetState(ICoffeeMachineState state) => _state = state;

        public void InsertCoin() => _state.InsertCoin();
        public void SelectDrink() => _state.SelectDrink();
        public void DispenseDrink() => _state.DispenseDrink();
    }


    interface IChatMediator
    {
        void SendMessage(string message, IChatMember sender);
        void AddMember(IChatMember member);
    }

    interface IChatMember
    {
        void Send(string message);
        void Receive(string message);
    }

    class ChatMediator : IChatMediator
    {
        private List<IChatMember> _members = new List<IChatMember>();

        public void AddMember(IChatMember member) => _members.Add(member);

        public void SendMessage(string message, IChatMember sender)
        {
            foreach (var member in _members)
                if (member != sender)
                    member.Receive(message);
        }
    }

    class ChatMember : IChatMember
    {
        private string _name;
        private IChatMediator _mediator;

        public ChatMember(string name, IChatMediator mediator)
        {
            _name = name;
            _mediator = mediator;
        }

        public void Send(string message) => _mediator.SendMessage(message, this);

        public void Receive(string message) => Console.WriteLine($"{_name} получил сообщение: {message}");
    }

    interface IOrder
    {
        int GetPrice();
        string GetDescription();
    }

    class BaseOrder : IOrder
    {
        public int GetPrice() => 100;
        public string GetDescription() => "Базовый заказ";
    }

    class FastDelivery : IOrder
    {
        private IOrder _order;

        public FastDelivery(IOrder order) => _order = order;

        public int GetPrice() => _order.GetPrice() + 30;
        public string GetDescription() => _order.GetDescription() + ", оперативная доставка";
    }

    class GiftWrap : IOrder
    {
        private IOrder _order;

        public GiftWrap(IOrder order) => _order = order;

        public int GetPrice() => _order.GetPrice() + 20;
        public string GetDescription() => _order.GetDescription() + ", упаковка подарков";
    }


    interface IService
    {
        string GetData();
    }

    class RealService : IService
    {
        public string GetData()
        {
            Thread.Sleep(3000);
            return "Данные с сервера";
        }
    }

    class ProxyService : IService
    {
        private RealService _realService;
        private string _cachedData;
        private DateTime _lastAccess;

        public string GetData()
        {
            if (_realService == null || (DateTime.Now - _lastAccess).TotalSeconds > 5)
            {
                _realService = new RealService();
                _cachedData = _realService.GetData();
                _lastAccess = DateTime.Now;
            }
            return _cachedData;
        }
    }
}
