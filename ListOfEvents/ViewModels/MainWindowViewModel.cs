using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using EventList.Models;
using EventList.ViewModels;
using ReactiveUI;

namespace EventList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Events> Kids;
        public ObservableCollection<Events> Sport;
        public ObservableCollection<Events> Culture;
        public ObservableCollection<Events> Excursions;
        public ObservableCollection<Events> Lifestyle;
        public ObservableCollection<Events> Party;
        public ObservableCollection<Events> Online;
        public ObservableCollection<Events> Show;
        public ObservableCollection<Events> Education;
        public MainWindowViewModel()
        {

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("..//..//..//..//CityEvents.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                Kids = new ObservableCollection<Events>();
                Sport = new ObservableCollection<Events>();
                Culture = new ObservableCollection<Events>();
                Excursions = new ObservableCollection<Events>();
                Lifestyle = new ObservableCollection<Events>();
                Party = new ObservableCollection<Events>();
                Online = new ObservableCollection<Events>();
                Show = new ObservableCollection<Events>();
                Education = new ObservableCollection<Events>();
                foreach (XmlElement xnode in xRoot)
                {
                    Events eventt = new Events();
                    XmlNode? attr = xnode.Attributes.GetNamedItem("name");
                    eventt.Name = attr?.Value + " ";

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "Description") 
                        { 
                            if (childnode.InnerText.Length >= 135)
                            {
                                eventt.Description = childnode.InnerText.Remove(135, childnode.InnerText.Length - 135) + "...";
                            }
                            else
                            {

                                eventt.Description = childnode.InnerText;
                            }
                        }
                        if (childnode.Name == "Image")
                            eventt.ImagePath = childnode.InnerText;
                        if (childnode.Name == "Date")
                            eventt.Date = childnode.InnerText;
                        if (childnode.Name == "Category")
                        {
                            foreach (XmlNode categorynode in childnode.ChildNodes)
                            {
                                
                                if (categorynode.InnerText == "Для Детей")
                                {
                                    Kids.Add(new Events { Name = eventt.Name, Description = eventt.Description, Date = eventt.Date, Price = eventt.Price, ImagePath = eventt.ImagePath });
                                }
                                if (categorynode.InnerText == "Спорт")
                                {
                                    Sport.Add(new Events { Name = eventt.Name, Description = eventt.Description, Date = eventt.Date, Price = eventt.Price, ImagePath = eventt.ImagePath });
                                }
                                if (categorynode.InnerText == "Культура")
                                {
                                    Culture.Add(new Events { Name = eventt.Name, Description = eventt.Description, Date = eventt.Date, Price = eventt.Price, ImagePath = eventt.ImagePath });
                                }
                                if (categorynode.InnerText == "Экскурсии")
                                {
                                    Excursions.Add(new Events { Name = eventt.Name, Description = eventt.Description, Date = eventt.Date, Price = eventt.Price, ImagePath = eventt.ImagePath });
                                }
                                if (categorynode.InnerText == "Образ Жизни")
                                {
                                    Lifestyle.Add(new Events { Name = eventt.Name, Description = eventt.Description, Date = eventt.Date, Price = eventt.Price, ImagePath = eventt.ImagePath });
                                }
                                if (categorynode.InnerText == "Образование")
                                {
                                    Education.Add(new Events { Name = eventt.Name, Description = eventt.Description, Date = eventt.Date, Price = eventt.Price, ImagePath = eventt.ImagePath });
                                }
                                if (categorynode.InnerText == "Вечеринки")
                                {
                                    Party.Add(new Events { Name = eventt.Name, Description = eventt.Description, Date = eventt.Date, Price = eventt.Price, ImagePath = eventt.ImagePath });
                                }
                                if (categorynode.InnerText == "Онлайн")
                                {
                                    Online.Add(new Events { Name = eventt.Name, Description = eventt.Description, Date = eventt.Date, Price = eventt.Price, ImagePath = eventt.ImagePath });
                                }
                                if (categorynode.InnerText == "Шоу")
                                {
                                    Show.Add(new Events { Name = eventt.Name, Description = eventt.Description, Date = eventt.Date, Price = eventt.Price, ImagePath = eventt.ImagePath });
                                }
                            }
                        }
                        if (childnode.Name == "Price")
                            eventt.Price = childnode.InnerText;
                    }
                }
            }
        }
        public ObservableCollection<Events> Kid{ get => Kids; set { this.RaiseAndSetIfChanged(ref Kids, value); } }
        public ObservableCollection<Events> SporT { get => Sport; set { this.RaiseAndSetIfChanged(ref Sport, value); } }
        public ObservableCollection<Events> CulturE { get => Culture; set { this.RaiseAndSetIfChanged(ref Culture, value); } }
        public ObservableCollection<Events> ExcursionS { get => Excursions; set { this.RaiseAndSetIfChanged(ref Excursions, value); } }
        public ObservableCollection<Events> LifestylE { get => Lifestyle; set { this.RaiseAndSetIfChanged(ref Lifestyle, value); } }
        public ObservableCollection<Events> EducatioN { get => Education; set { this.RaiseAndSetIfChanged(ref Education, value); } }
        public ObservableCollection<Events> PartY { get => Party; set { this.RaiseAndSetIfChanged(ref Party, value); } }
        public ObservableCollection<Events> OnlinE { get => Online; set { this.RaiseAndSetIfChanged(ref Online, value); } }
        public ObservableCollection<Events> ShoW { get => Show; set { this.RaiseAndSetIfChanged(ref Show, value); } }
    }
}
