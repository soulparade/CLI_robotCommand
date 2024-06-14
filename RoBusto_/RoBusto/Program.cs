namespace RoBusto;
using System;


public class Program()
{
    static void Main()
    {

        Braccio bracciosx = Utils.DeserializeBraccio("BraccioSX");
        Braccio bracciodx = Utils.DeserializeBraccio("BraccioDX");
        
        Console.WriteLine("Scegliere il Nome del File di log: ");
        string logfile = Console.ReadLine() ?? "Unknown message id: 42";

        do
        {
            Console.WriteLine("scelta braccio: 0 = dx / 1 = sx / altro numero = andare avanti( pannello comunicazione )");
            int scelta = Convert.ToInt32(Console.ReadLine());

            switch (scelta)
            {
                case 0:
                    Console.WriteLine("\n-0 spalla\n-1 gomito\n2- polso\n3- mano");
                    scelta = Convert.ToInt32(Console.ReadLine());

                    switch (scelta)
                    {
                        case 0:
                            foreach (var servo in bracciodx.Spalla.Servi)
                            {
                                Console.WriteLine("Spalla destra:\n\n");

                                Console.WriteLine("\nModificabili: \n0)AngoloMax: " + servo.AngMax + "\n1)AngoloMin: " + servo.AngMin + "\n2)AngoloAttuale: " + servo.AngAtt);

                                Console.WriteLine("\nModificare qualcosa? Y/N");
                                string modificaSpalla = Console.ReadLine();

                                while ( modificaSpalla.ToUpper() == "Y" )
                                {
                                    Console.WriteLine("cosa si vuole Cambiare?");
                                    int parametroDaCambiare = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("nuovo valore: ");
                                    int valore = Convert.ToInt32(Console.ReadLine());

                                    switch (parametroDaCambiare)
                                    {
                                        case 0:
                                            servo.AngMax = servo.Modifica(servo.AngMax, valore);
                                            Console.WriteLine("valore nuovo:" + servo.AngMax);
                                            break;
                                        case 1:
                                            servo.AngMin = servo.Modifica(servo.AngMin, valore);
                                            Console.WriteLine("valore nuovo:" + servo.AngMin);
                                            break;
                                        case 2:
                                            servo.AngAtt = servo.Modifica(servo.AngAtt, valore);
                                            Console.WriteLine("valore nuovo:" + servo.AngAtt);
                                            break;
                                        default:
                                            Console.WriteLine("Errore, switch dx");
                                            break;
                                    }
                                    Console.WriteLine("\nModificare qualcosa? Y/N ");
                                    modificaSpalla = Console.ReadLine();
                                }
                            }
                            break;
                        case 1:
                            Console.WriteLine("Gomito destro:\n\n");

                            Console.WriteLine("\nModificabili: \n0)AngoloMax: " + bracciodx.Gomito.AngMax + "\n1)AngoloMin: " + bracciodx.Gomito.AngMin + "\n2)AngoloAttuale: " + bracciodx.Gomito.AngAtt);

                            Console.WriteLine("\nModificare qualcosa? Y/N ");
                            string modificaGomito = Console.ReadLine();

                            while (modificaGomito.ToUpper() == "Y" )
                            {
                                Console.WriteLine("cosa si vuole Cambiare?");
                                int parametroDaCambiare = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("nuovo valore: ");
                                int valore = Convert.ToInt32(Console.ReadLine());

                                switch (parametroDaCambiare)
                                {
                                    case 0:
                                        bracciosx.Gomito.AngMax = bracciosx.Gomito.Modifica(bracciosx.Gomito.AngMax, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Gomito.AngMax);
                                        break;
                                    case 1:
                                        bracciosx.Gomito.AngMin = bracciosx.Gomito.Modifica(bracciosx.Gomito.AngMin, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Gomito.AngMin);
                                        break;
                                    case 2:
                                        bracciosx.Gomito.AngAtt = bracciosx.Gomito.Modifica(bracciosx.Gomito.AngAtt, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Gomito.AngAtt);
                                        break;
                                    default:
                                        Console.WriteLine("Errore, switch dx"); break;
                                }
                                Console.WriteLine("\nModificare qualcosa? Y/N ");
                                modificaGomito = Console.ReadLine();

                            }
                            break;
                        case 2:
                            Console.WriteLine("Polso destro:\n\n");

                            Console.WriteLine("\nModificabili: \n0)AngoloMax: " + bracciodx.Polso.AngMax + "\n1)AngoloMin: " + bracciodx.Polso.AngMin + "\n2)AngoloAttuale: " + bracciodx.Polso.AngAtt);

                            Console.WriteLine("\nModificare qualcosa? Y/N ");
                            string modificaPolso = Console.ReadLine();

                            while (modificaPolso.ToUpper() == "Y" )
                            {
                                Console.WriteLine("cosa si vuole Cambiare?");
                                int parametroDaCambiare = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("nuovo valore: ");
                                int valore = Convert.ToInt32(Console.ReadLine());

                                switch (parametroDaCambiare)
                                {
                                    case 0:
                                        bracciosx.Polso.AngMax = bracciosx.Polso.Modifica(bracciosx.Polso.AngMax, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Polso.AngMax);
                                        break;
                                    case 1:
                                        bracciosx.Polso.AngMin = bracciosx.Polso.Modifica(bracciosx.Polso.AngMin, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Polso.AngMin);
                                        break;
                                    case 2:
                                        bracciosx.Polso.AngAtt = bracciosx.Polso.Modifica(bracciosx.Polso.AngAtt, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Polso.AngAtt);
                                        break;
                                    default:
                                        Console.WriteLine("Errore, switch dx"); break;
                                }
                                Console.WriteLine("\nModificare qualcosa? Y/N ");
                                modificaPolso = Console.ReadLine();

                            }

                            break;
                        case 3:
                            foreach ( var dito in bracciodx.Mano.Dita)
                            {
                                string nMano = "manodx";
                                string nDito = dito.Name;

                                Console.WriteLine("Mano destra:\n\n");// right hand

                                Console.WriteLine(dito.Name+": ");
                                Console.WriteLine("\nModificabili: \n0)AngoloMax: " + dito.AngMax + "\n1)AngoloMin: " + dito.AngMin + "\n2)AngoloAttuale: " + dito.AngAtt);

                                Console.WriteLine("\nModificare qualcosa? Y/N ");
                                string modificaMano = Console.ReadLine();

                                while ( modificaMano.ToUpper() == "Y" )
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

                                            string data = Convert.ToString(dito.AngMax);        // dati parametro
                                            string nParametro = "AngMax";                       // nome parametro cambiato 3
                                            dito.log(nMano, nDito, nParametro, data, logfile);
                                            break;
                                        case 1:
                                            dito.AngMin = dito.Modifica(dito.AngMin, valore);
                                            Console.WriteLine("valore nuovo:" + dito.AngMin);

                                            data = Convert.ToString(dito.AngMin);               // dati parametro
                                            nParametro = "AngMin";                              // nome parametro cambiato 3
                                            dito.log(nMano, nDito, nParametro, data, logfile);
                                            break;
                                        case 2:
                                            dito.AngAtt = dito.Modifica(dito.AngAtt, valore);
                                            Console.WriteLine("valore nuovo:" + dito.AngAtt);

                                            data = Convert.ToString(dito.AngAtt);               // dati parametro
                                            nParametro = "AngAtt";                              // nome parametro cambiato 3
                                            dito.log(nMano, nDito, nParametro, data, logfile);
                                                    break;
                                        default:
                                            Console.WriteLine("Errore, switch dx");
                                            break;
                                    }
                                    Console.WriteLine("\nModificare qualcosa? Y/N ");
                                    modificaMano = Console.ReadLine();
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Errore, valore non riconosciuto");
                            break;
                    }
                    break;
                case 1:     // sinistra
                    Console.WriteLine("\n-0 spalla\n-1 gomito\n2- polso\n3- mano");
                    scelta = Convert.ToInt32(Console.ReadLine());

                    switch (scelta)
                    {
                        case 0:
                            foreach (var servo in bracciosx.Spalla.Servi)
                            {
                                Console.WriteLine("Spalla destra:\n\n");

                                Console.WriteLine("\nModificabili: \n0)AngoloMax: " + servo.AngMax + "\n1)AngoloMin: " + servo.AngMin + "\n2)AngoloAttuale: " + servo.AngAtt);

                                Console.WriteLine("\nModificare qualcosa? Y/N ");
                                string modificaSpalla = Console.ReadLine();

                                while ( modificaSpalla.ToUpper() == "Y" )
                                {
                                    Console.WriteLine("cosa si vuole Cambiare?");
                                    int parametroDaCambiare = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("nuovo valore: ");
                                    int valore = Convert.ToInt32(Console.ReadLine());

                                    switch (parametroDaCambiare)
                                    {
                                        case 0:
                                            servo.AngMax = servo.Modifica(servo.AngMax, valore);
                                            Console.WriteLine("valore nuovo:" + servo.AngMax);
                                            break;
                                        case 1:
                                            servo.AngMin = servo.Modifica(servo.AngMin, valore);
                                            Console.WriteLine("valore nuovo:" + servo.AngMin);
                                            break;
                                        case 2:
                                            servo.AngAtt = servo.Modifica(servo.AngAtt, valore);
                                            Console.WriteLine("valore nuovo:" + servo.AngAtt);
                                            break;
                                        default:
                                            Console.WriteLine("Errore, switch dx");
                                            break;
                                    }
                                    Console.WriteLine("\nModificare qualcosa? Y/N ");
                                    modificaSpalla = Console.ReadLine();
                                }
                            }
                            break;
                        case 1:
                            Console.WriteLine("Gomito sinistro:\n\n");

                            Console.WriteLine("\nModificabili: \n0)AngoloMax: " + bracciosx.Gomito.AngMax + "\n1)AngoloMin: " + bracciosx.Gomito.AngMin + "\n2)AngoloAttuale: " + bracciosx.Gomito.AngAtt);

                            Console.WriteLine("\nModificare qualcosa? Y/N ");
                            string modificaGomito = Console.ReadLine();

                            while ( modificaGomito.ToUpper() == "Y" )
                            {
                                Console.WriteLine("cosa si vuole Cambiare?");
                                int parametroDaCambiare = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("nuovo valore: ");
                                int valore = Convert.ToInt32(Console.ReadLine());

                                switch (parametroDaCambiare)
                                {
                                    case 0:
                                        bracciosx.Gomito.AngMax = bracciosx.Gomito.Modifica(bracciosx.Gomito.AngMax, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Gomito.AngMax);
                                        break;
                                    case 1:
                                        bracciosx.Gomito.AngMin = bracciosx.Gomito.Modifica(bracciosx.Gomito.AngMin, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Gomito.AngMin);
                                        break;
                                    case 2:
                                        bracciosx.Gomito.AngAtt = bracciosx.Gomito.Modifica(bracciosx.Gomito.AngAtt, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Gomito.AngAtt);
                                        break;
                                    default:
                                        Console.WriteLine("Errore, switch dx"); break;
                                }
                                    Console.WriteLine("\nModificare qualcosa? Y/N ");
                                    modificaGomito = Console.ReadLine();

                            }
                            break;
                        case 2:
                            Console.WriteLine("Polso sinistro:\n\n");

                            Console.WriteLine("\nModificabili: \n0)AngoloMax: " + bracciosx.Polso.AngMax + "\n1)AngoloMin: " + bracciosx.Polso.AngMin + "\n2)AngoloAttuale: " + bracciosx.Polso.AngAtt);

                            Console.WriteLine("\nModificare qualcosa? Y/N ");
                            string modificaPolso = Console.ReadLine();

                            while ( modificaPolso.ToUpper() == "Y" )
                            {
                                Console.WriteLine("cosa si vuole Cambiare?");
                                int parametroDaCambiare = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("nuovo valore: ");
                                int valore = Convert.ToInt32(Console.ReadLine());

                                switch (parametroDaCambiare)
                                {
                                    case 0:
                                        bracciosx.Polso.AngMax = bracciosx.Polso.Modifica(bracciosx.Polso.AngMax, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Polso.AngMax);
                                        break;
                                    case 1:
                                        bracciosx.Polso.AngMin = bracciosx.Polso.Modifica(bracciosx.Polso.AngMin, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Polso.AngMin);
                                        break;
                                    case 2:
                                        bracciosx.Polso.AngAtt = bracciosx.Polso.Modifica(bracciosx.Polso.AngAtt, valore);
                                        Console.WriteLine("valore nuovo:" + bracciosx.Polso.AngAtt);
                                        break;
                                    default:
                                        Console.WriteLine("Errore, switch sx"); break;
                                }
                                    Console.WriteLine("\nModificare qualcosa? Y/N ");
                                    modificaPolso = Console.ReadLine();

                            }

                            break;
                        case 3:
                            foreach ( var dito in bracciosx.Mano.Dita)
                            {
                                string nMano = "manosx";
                                string nDito = dito.Name;

                                Console.WriteLine("Mano sinistra:\n\n");

                                Console.WriteLine(dito.Name+": ");
                                Console.WriteLine("\nModificabili: \n0)AngoloMax: " + dito.AngMax + "\n1)AngoloMin: " + dito.AngMin + "\n2)AngoloAttuale: " + dito.AngAtt);

                                Console.WriteLine("\nModificare qualcosa? Y/N ");
                                string modificaMano = Console.ReadLine();

                                while ( modificaMano.ToUpper() == "Y" )
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
                                    modificaMano = Console.ReadLine();
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Errore, valore non riconosciuto");
                            break;
                    }
                    break;
                default:
                    break;
            }

            if (scelta > 1)
            {
                Utils.SerializeAndSaveBraccio(bracciodx, "BraccioDX");
                Utils.SerializeAndSaveBraccio(bracciosx, "BraccioSX");
                break;
            }

        } while (true);

        Pannello_Di_Comunicazione pannello = new Pannello_Di_Comunicazione();

        pannello.Comunicazione();

    }
}
