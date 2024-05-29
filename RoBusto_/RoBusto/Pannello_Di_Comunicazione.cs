namespace RoBusto;

public class Pannello_Di_Comunicazione
{
    /*static SerialPort _serialPort;
        
    public static Braccio Bracciodx = Utils.DeserializeBraccio("Record_Angoli_DX");

    public void Comunicazione()
    {
        _serialPort = new SerialPort(portName: "COM3", baudRate: 9600);

        try
        {
            _serialPort.Open();

            if( _serialPort.IsOpen )
            {
                //Thread thread1 = new Thread(ReadFromSerial);
                Thread thread2 = new Thread(WriteToSerial);

                //thread1.Start();
                thread2.Start();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Si è verificato un'errore durante l'apertura della porta seriale: " + ex.Message);
        }

                
    }

    static void ReadFromSerial()
    {
        while (true)
        {
            try
            { 
                string stato = _serialPort.ReadExisting(); 
                if ( stato != null ) 
                {
                    double value = Convert.ToDouble(stato);

                    Console.WriteLine(value);
                }
                Thread.Sleep(500);
                        
                        
            }
            catch (TimeoutException) { }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante la lettura dalla porta seriale: " + ex.Message);
            }
        }
    }

    public static void WriteToSerial()
    {
        string[] VetPos = new string[6];
        string[] PosPrecedenti = new string[6];
        int i = 0; 
        foreach (KeyValuePair<string, Dito> pair in Bracciodx.mano.dita)
        {
            PosPrecedenti[i] = Convert.ToString(Bracciodx.mano.dita[pair.Key].Motore.AngMin);
            i++;
        }
        PosPrecedenti[5] = Convert.ToString(Bracciodx.polso.AngDritto);

        while (true)
        { 
            try
            {

                Console.WriteLine("Inserire scelta: 0 singoli angoli, 1 posizioni preimpostate: ");
                int scelta = Convert.ToInt32(Console.ReadLine());
                if ( scelta == 0)
                { 
                    i = 0;
                    foreach (KeyValuePair<string, Dito> pair in Bracciodx.mano.dita)
                    {
                        Console.WriteLine("Inserire l'angolo del dito: " + Bracciodx.mano.dita[pair.Key].Nome + " ( AngMax: " + Bracciodx.mano.dita[pair.Key].Motore.AngMax + "; AngMin: " + Bracciodx.mano.dita[pair.Key].Motore.AngMin + ") "); 
                        VetPos[i] = Console.ReadLine();

                        if (VetPos[i] == "")
                        { 
                            VetPos[i] = PosPrecedenti[i];
                        }
                        else
                        { 
                            while (Convert.ToInt32(VetPos[i]) < Bracciodx.mano.dita[pair.Key].Motore.AngMin || Convert.ToInt32(VetPos[i]) > Bracciodx.mano.dita[pair.Key].Motore.AngMax)
                            { 
                                Console.WriteLine("Valore non compreso tra massimo e minimo, reinserire il valore: "); 
                                VetPos[i] = Console.ReadLine();
                            }
                            PosPrecedenti[i] = VetPos[i];

                            Bracciodx.mano.dita[pair.Key].Motore.AngAtt = Convert.ToInt32(VetPos[i]);

                        }

                        i++;
                    }

                    Console.WriteLine("Inserire l'angolo del polso( 70 min, 160 max, 120 dritto ) : ");
                    VetPos[5] = Console.ReadLine();

                    if (VetPos[5] == "")
                    { 
                        VetPos[5] = PosPrecedenti[5];
                    }
                    else
                    {
                        while ( Convert.ToInt32(VetPos[5]) > Bracciodx.polso.Motore.AngMax || Convert.ToInt32(VetPos[5]) < Bracciodx.polso.Motore.AngMin )
                        { 
                            Console.WriteLine("Valore non compreso tra massimo e minimo, reinserire il valore: "); 
                            VetPos[5] = Console.ReadLine();
                        }
                    }

                    Utils.SerializeAndSaveBraccio(Bracciodx, "Record_Angoli_DX");

                        
                }

                if ( scelta == 1 )
                { 
                    Console.WriteLine("0)Apri Mano\n1)Chiudo Mano\n2)Segno Vittoria\n3)Ok\n4)Saluto\n"); 
                    scelta = Convert.ToInt32(Console.ReadLine());

                    switch ( scelta)
                      
                    {
                        case 0: 
                            // apri mano
                            Bracciodx.mano.ApriMano();
                            break;
                        case 1:
                            // chiudi mano
                            Bracciodx.mano.ChiudiMano();
                            break;
                        case 2:
                            // segno vittoria 
                            Bracciodx.mano.dita["pollice"].Motore.ChiudiMin();
                            Bracciodx.mano.dita["indice"].Motore.ApriMax();
                            Bracciodx.mano.dita["medio"].Motore.ApriMax();
                            Bracciodx.mano.dita["anulare"].Motore.ChiudiMin();
                            Bracciodx.mano.dita["mignolo"].Motore.ChiudiMin();
                                break;
                        case 3:
                                // ok
                            Bracciodx.mano.dita["pollice"].Motore.ApriMax();
                            Bracciodx.mano.dita["indice"].Motore.ChiudiMin();
                            Bracciodx.mano.dita["medio"].Motore.ChiudiMin();
                            Bracciodx.mano.dita["anulare"].Motore.ChiudiMin(); 
                            Bracciodx.mano.dita["mignolo"].Motore.ChiudiMin();
                            break;
                        case 4:
                            //saluto
                            Bracciodx.mano.ApriMano();
                            break;
                        default:
                            Console.WriteLine("Comando inesistente."); 
                            break;
                    }
                    VetPos[0] = Convert.ToString(Bracciodx.mano.dita["pollice"].Motore.AngAtt); 
                    VetPos[1] = Convert.ToString(Bracciodx.mano.dita["indice"].Motore.AngAtt); 
                    VetPos[2] = Convert.ToString(Bracciodx.mano.dita["medio"].Motore.AngAtt); 
                    VetPos[3] = Convert.ToString(Bracciodx.mano.dita["anulare"].Motore.AngAtt); 
                    VetPos[4] = Convert.ToString(Bracciodx.mano.dita["mignolo"].Motore.AngAtt); 
                }
                string Pos = "handdx"+String.Join(",",VetPos);
                Console.WriteLine(Pos);
                _serialPort.Write(Pos);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            
            { Console.WriteLine("Errore durante la scrittura sulla porta seriale: " + ex.Message);
            }
        }
    }*/
}
