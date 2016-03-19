using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Project2
{
    public class Room
    {
        //An arraylist to hold the upgrades for each room. So each room may have multiple upgrades.
        ArrayList arrUpgrades = new ArrayList();

        //Property values for the Rooms
        private String description;
        private double price;
        private double upgradecost;
        private double totalcost;
        private double length;
        private double width;
        private String completedescription;

        //Method to add an upgrade to a room and it adds an upgrade object to the array of upgrades.
        //It also updates the total upgrade costs and updates the total costs for both the room and the upgrades.
        public void addUpgrade(Upgrade newUpgrade)
        {
            arrUpgrades.Add(newUpgrade);
            CalculateUpgradeCosts();
            CalculateTotalCosts();
        }

        //Method to remove an upgrade from a room and the array of upgrades. It searches the arraylist of upgrades
        //to see if the string description matches and then removes it.
        public void removeUpgrade(Upgrade upgradetoremove)
        {
            foreach (Upgrade currentUpgrade in arrUpgrades)
            {
                if (currentUpgrade.UpgradeDescription.Equals(upgradetoremove.UpgradeDescription))
                {
                    arrUpgrades.Remove(currentUpgrade);
                }
            }
        }

        //Method to update the combined description used for making the output gridview. The completedecription
        //property holds the description along with the upgrade description.
        public void addUpgradeToDescription(String upgradedescription)
        {
            completedescription = completedescription + " and " + upgradedescription;
        }

        //Method to calculate the upgrade cost by looping through the upgrade arraylist and adding the price from
        //each upgrade in the arraylist
        public void CalculateUpgradeCosts()
        {
            foreach (Upgrade currentUpgrade in arrUpgrades)
            {
                upgradecost = upgradecost + currentUpgrade.UpgradePrice;
            }
        }

        //Method to calculate the total cost of the room by adding the price of the room and the upgrade costs
        public void CalculateTotalCosts()
        {
            totalcost = price + upgradecost;
        }

        //Setter and Getter for the Description of the room and the description is the unique identifier to search
        //for rooms.
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        //Setter and Getter for the other properties of the room. These are the values that will be used for the
        //output gridview and will displayed in the output gridview.
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public double UpgradeCost
        {
            get { return upgradecost; }
            set { upgradecost = value; }
        }
        public double TotalCost
        {
            get { return totalcost; }
            set { totalcost = value; }
        }
        public String CompleteDescription
        {
            get { return completedescription; }
            set { completedescription = value; }
        }

        //Setter and Getter for the length and width. Might not be used, just stored for now incase they are needed
        //at a later time.
        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        public double Width
        {
            get { return width; }
            set { width = value; }
        }



    }
}