using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Project2
{
    public class Home
    {
        public ArrayList arrRooms = new ArrayList();

        //Properties that might not be needed. I have it here incase I need it for later.
        //public String Description;
        //public int Price;
        //public int UpgradeCost;
        //public int TotalCost;
        //public int GrandTotal;

        //Method to create a room object after being passed the description, price, length, and width. It calculates
        //the price of the room by multiplying the length and width with the price. It will also update the complete
        //description with the room description along with the measurements for the room. The method will then add
        //the room object to the room arraylist which holds all the rooms for the house.
        public void AddRoom(String description, double price, double length, double width)
        {
            double squarefeet = length * width;
            double newPrice = price * squarefeet;

            Room newRoom = new Room();
            newRoom.Description = description;
            newRoom.Price = newPrice;
            newRoom.Length = length;
            newRoom.Width = width;
            newRoom.CompleteDescription = description + " (" + length + "x" + width + ") ";
            newRoom.CalculateTotalCosts();

            arrRooms.Add(newRoom);
        }

        //Method to remove a room object from the room arraylist by passing the room description. It will loop through
        //the arraylist comparing each room object's description with the description passed and if it matches, it will
        //remove that room from the room arraylist.
        public void RemoveRoom(String description)
        {
            foreach (Room currentRoom in arrRooms)
            {
                if (currentRoom.Description.Equals(description))
                {
                    arrRooms.Remove(currentRoom);
                }
            }
        }

        //Method to create an upgrade object after being passed the room description, upgrade description, and upgrade
        //price. It first creates an upgrade object and then loop through the room arraylist comparing the room description
        //passed with each room's description. If it matches, it calls the current room's method to add the upgrade to the
        //upgrade arraylist for the room. It also calls the room's upgrade description method to add the name of the
        //upgrade to the complete description for the room.
        public void addUpgrade(String description, String upgradescription, double upgradeprice)
        {
            Upgrade newUpgrade = new Upgrade();
            newUpgrade.UpgradeDescription = upgradescription;
            newUpgrade.UpgradePrice = upgradeprice;

            foreach (Room currentRoom in arrRooms)
            {
                if (currentRoom.Description.Equals(description))
                {
                    currentRoom.addUpgradeToDescription(newUpgrade.UpgradeDescription);
                    currentRoom.addUpgrade(newUpgrade);
                }
            }
        }

        //Method to remove an upgrade object from the upgrade arraylist for the specified room by passing the room
        //description, upgrade description, and upgrade price. It creates an upgrade object used to compare with the
        //upgrades in the upgrade arraylist for the room. It loops through the room arraylist using the room description
        //to get the right room and then calls the current room's method to remove an upgrade passing the new upgrade
        //oobject.
        public void removeUpgrade(String description, String upgradedescription, double upgradeprice)
        {
            Upgrade upgradeToRemove = new Upgrade();
            upgradeToRemove.UpgradeDescription = upgradedescription;
            upgradeToRemove.UpgradePrice = upgradeprice;

            foreach (Room currentRoom in arrRooms)
            {
                if (currentRoom.Description.Equals(description))
                {
                    currentRoom.removeUpgrade(upgradeToRemove);
                }
            }
        }
    }
}