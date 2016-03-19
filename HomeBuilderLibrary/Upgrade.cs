using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2
{
    public class Upgrade
    {
        //Property values for an Upgrade.
        private String upgradeDescription;
        private double upgradePrice;

        //Setter and Getter to retrieve the values of the properties. Also used to by other methods when
        //searching through a room's upgrade arraylist and upgradeDescription is used as a unique identifier
        //for an upgrade to be able to search for a specific upgrade.
        public String UpgradeDescription
        {
            get { return upgradeDescription; }
            set { upgradeDescription = value; }
        }
        public double UpgradePrice
        {
            get { return upgradePrice; }
            set { upgradePrice = value; }
        }
    }
}