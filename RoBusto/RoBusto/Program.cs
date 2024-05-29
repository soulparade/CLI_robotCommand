// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using RoBusto;


Console.WriteLine("Hello, World!");

string jsonStr = File.ReadAllText("C:\\Users\\user\\Desktop\\RoBusto\\RoBusto\\bin\\Debug\\test.json");
Braccio bracciodx = new Braccio( "bracciodx", new Spalla([new Servo(0,0,0,0), new Servo(0,0,0,0) ]),new Gomito(0,0,0,0,"gomito"), new Polso(0,0,0,0, "polso"), new Mano([new Dito(0, 0, 0, 0, "hello"), new Dito(0, 0, 0, 0, "hello"),new Dito(0, 0, 0, 0, "hello"),new Dito(0, 0, 0, 0, "hello"),new Dito(0, 0, 0, 0, "hello"),]));
Braccio bracciosx = new Braccio( "bracciodx", new Spalla([new Servo(0,0,0,0), new Servo(0,0,0,0) ]),new Gomito(0,0,0,0,"gomito"), new Polso(0,0,0,0, "polso"), new Mano([new Dito(0, 0, 0, 0, "hello"), new Dito(0, 0, 0, 0, "hello"),new Dito(0, 0, 0, 0, "hello"),new Dito(0, 0, 0, 0, "hello"),new Dito(0, 0, 0, 0, "hello"),]));

//Braccio bracciodx = Utils.DeserializeBraccio("test");
/*
 I need to do: Braccio braccio = Utils.DeserializeBraccio("Record_Angoli_XX");
 but it doesen't work due to the constractor that i made
 i'd make another constructor maybe i don't know


*/
//string testjson = JsonSerializer.Serialize(bracciodx);
//Console.WriteLine(testjson);
//Utils.SerializeAndSaveBraccio(bracciodx,"test");

Console.WriteLine("Scegliere il Nome del File di log: ");
string logfile = Console.ReadLine();



do
{
  
    Console.WriteLine("scelta mano: 0 = dx / 1 = sx / altro numero = andare avanti( pannello comunicazione )");
    int scelta = Convert.ToInt32(Console.ReadLine());

    switch (scelta)
    {
        case 0:
            foreach ( var dito in bracciodx.Mano.Dita)
            {
                string nMano = "manodx";
                string nDito = dito.Name;

                Console.WriteLine(dito.AngMax);

                Console.WriteLine("Mano destra:\n\n");// right hand

                Console.WriteLine(dito.Name+": ");// finger's name
                Console.WriteLine("\nModificabili: \n0)AngoloMax: " + dito.AngMax + "\n1)AngoloMin: " + dito.AngMin + "\n2)AngoloAttuale: " + dito.AngAtt);
                
                Console.WriteLine("\nModificare qualcosa? Y/N ");// change something?
                string modifica = Console.ReadLine();

                while ( modifica == "Y" || modifica == "y" )
                {
                    Console.WriteLine("cosa si vuole Cambiare?");// what do you want to change?
                    int parametroDaCambiare = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("nuovo valore: ");
                    int valore = Convert.ToInt32(Console.ReadLine());

                    switch (parametroDaCambiare)
                    {
                        case 0:

                            dito.AngMax = dito.Modifica(dito.AngMax, valore);
                            Console.WriteLine("valore nuovo:" + dito.AngMax);

                            string data = Convert.ToString(dito.AngMax); // dati parametro
                            string nParametro = "AngMax";  // nome parametro cambiato 3
                            dito.log(nMano, nDito, nParametro, data, logfile);
                            break;
                        case 1:

                            dito.AngMin = dito.Modifica(dito.AngMin, valore);
                            Console.WriteLine("valore nuovo:" + dito.AngMin);

                            data = Convert.ToString(dito.AngMin); // dati parametro
                            nParametro = "AngMin";  // nome parametro cambiato 3
                            dito.log(nMano, nDito, nParametro, data, logfile);
                            break;
                        case 2:

                            dito.AngAtt = dito.Modifica(dito.AngAtt, valore);
                            Console.WriteLine("valore nuovo:" + dito.AngAtt);

                            data = Convert.ToString(dito.AngAtt); // dati parametro
                            nParametro = "AngAtt";  // nome parametro cambiato 3
                            dito.log(nMano, nDito, nParametro, data, logfile);
                                    break;
                        default:
                            Console.WriteLine("Errore, switch dx");
                            break;
                    }
                    Console.WriteLine("\nModificare qualcosa? Y/N ");
                    modifica = Console.ReadLine();
                }
            }
            break;
        case 1:
            foreach ( var dito in bracciosx.Mano.Dita)
            {
                string nMano = "manosx";
                string nDito = dito.Name;

                Console.WriteLine(dito.AngMax);

                Console.WriteLine("Mano destra:\n\n");

                Console.WriteLine(dito.Name+": ");
                Console.WriteLine("\nModificabili: \n0)AngoloMax: " + dito.AngMax + "\n1)AngoloMin: " + dito.AngMin + "\n2)AngoloAttuale: " + dito.AngAtt);
                
                Console.WriteLine("\nModificare qualcosa? Y/N ");
                string modifica = Console.ReadLine();

                while ( modifica == "Y" || modifica == "y" )
                {
                    Console.WriteLine("cosa si vuole Cambiare?");
                    int parametroDaCambiare = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("nuovo valore: ");
                    int valore = Convert.ToInt32(Console.ReadLine());

                    switch (parametroDaCambiare)
                    {
                        case 0:

                            dito.AngMax = dito.Modifica(dito.AngMax, valore);
                            Console.WriteLine("valore nuovo:" + dito.AngMax);

                            string data = Convert.ToString(dito.AngMax); // dati parametro
                            string nParametro = "AngMax";  // nome parametro cambiato 3
                            dito.log(nMano, nDito, nParametro, data, logfile);
                            break;
                        case 1:

                            dito.AngMin = dito.Modifica(dito.AngMin, valore);
                            Console.WriteLine("valore nuovo:" + dito.AngMin);

                            data = Convert.ToString(dito.AngMin); // dati parametro
                            nParametro = "AngMin";  // nome parametro cambiato 3
                            dito.log(nMano, nDito, nParametro, data, logfile);
                            break;
                        case 2:

                            dito.AngAtt = dito.Modifica(dito.AngAtt, valore);
                            Console.WriteLine("valore nuovo:" + dito.AngAtt);

                            data = Convert.ToString(dito.AngAtt); // dati parametro
                            nParametro = "AngAtt";  // nome parametro cambiato 3
                            dito.log(nMano, nDito, nParametro, data, logfile);
                                    break;
                        default:
                            Console.WriteLine("Errore, switch dx");
                            break;
                    }
                    Console.WriteLine("\nModificare qualcosa? Y/N ");
                    modifica = Console.ReadLine();
                }
            }
            break;
        default:
            break;



    }

    if (scelta > 1)
    {
        Utils.SerializeAndSaveBraccio(bracciodx, "Record_Angoli_DX");
        //Utils.SerializeAndSaveBraccio(bracciosx, "Record_Angoli_SX");
        break;
    }
    
} while (true);


