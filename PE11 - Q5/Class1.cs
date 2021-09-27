using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE11___Q5
{
    public class Class1
    {
        public virtual void LoadPassenger() { }

        [+A:Vehicle|+LoadPassenger():v]
        [+A:Car| | ]
        [+I:IPassengerCarrier| |LoadPassenger()]
        [+I:IHeavyLoaderCarrier| | ]
        [+A:Train| | ]

        [+Compact| | ]
        [+SUV| | ]
        [+Pickup| | ]
        [+PassengerTrain| | ]
        [+FreightTrain| | ]
        [+424DoubleBogey| | ]

        [+A:Vehicle] <- [+A:Car]
        [+A:Vehicle] <- [+A:Train]

        [+A:Car] <- [+Compact]
        [+A:Car] <- [+SUV]
        [+A:Car] <- [+Pickup]

        [+A:Train] <- [+FreightTrain]
        [+A:Train] <- [+424DoubleBogey]
        [+A:Train] <- [+PassengerTrain]

        [+I:IPassengerCarrier] ^ [+Compact]
        [+I:IPassengerCarrier] ^ [+SUV]
        [+I:IPassengerCarrier] ^ [+Pickup]
        [+I:IPassengerCarrier] ^ [+PassengerTrain]

        [+I:IHeavyLoaderCarrier] ^ [+Pickup]
        [+I:IHeavyLoaderCarrier] ^ [+FreightTrain]
        [+I:IHeavyLoaderCarrier] ^ [+424DoubleBogey]
    }
}
