﻿using ChocAnDatabase;
using ReportGenerator;
using ReportGenerator.Factory;
using System;

namespace ManagerTerminal {
    public class ReportServices {
        public void CreateReport() {
            //TODO: This needs to be redone as it was originally built to be kicked off
            //      with a console for testing
            
            Console.Write("Enter 1 to generate provider report, 2 for member, 3 for summary: ");
            int choice = Console.Read();

            try 
            {
                int id = 3;

                var typeOfReport = (TypeOfReport)choice;
                var database = new DatabaseWrapper();
                var reportFactory = new ReportFactory();

                // This is how you call the report generator
                Processor processor = new Processor();
                (bool created, String errorMessage) result = processor.GenerateReport(typeOfReport, database, reportFactory, id);

                if (!result.created)
                    Console.WriteLine(result.errorMessage);
                else
                    Console.WriteLine("Successful");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
