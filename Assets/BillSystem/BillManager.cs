﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BillManager : MonoBehaviour {

    public static BillManager instance;
    public static List<ElectricityBill> electricitybills;
    void Start()
    {
        instance = this;
        electricitybills = new List<ElectricityBill>();
    }

    //issue all the bills at their set times in update.
    void Update()
   { 
        IssueElectricityBill();
        IssueInternetBill();
    }

    void IssueElectricityBill()
    {
        if (TimeManager.currentTime.DayOfWeek == System.DayOfWeek.Tuesday || 
            TimeManager.currentTime.DayOfWeek == System.DayOfWeek.Thursday)
        {
            // so long as this bill does not already exist it may currently spawn.
            //TODO bill list.
            if (ElectricityBill.instance.Exists != true) { ElectricityBill.instance.Electricity(); }
          
        }
    }

    void IssueInternetBill()
    {
        if (TimeManager.currentTime.DayOfWeek == System.DayOfWeek.Tuesday ||
            TimeManager.currentTime.DayOfWeek == System.DayOfWeek.Thursday)
            // so long as this bill does not already exist it may currently spawn.         
            if (InternetBill.instance.Exists != true) { InternetBill.instance.Internet(); } 

    }

    IEnumerable<ElectricityBill> electricitybill =
        from ElectricityBill in electricitybills     
        where ElectricityBill.Exists = true
        select ElectricityBill;
}
 