namespace RoBusto;


public class Pannello_Di_Comunicazione : System.ComponentModel.Component
{
    static SerialPort _serialPort;
    
        
    public static Braccio bracciodx = Utils.DeserializeBraccio("Record_Angoli_DX");

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
        string[] vetPos = new string[6];
        string[] posPrecedenti = new string[6];
        int i = 0; 
        foreach (var dito  in bracciodx.Mano.Dita)
        {
            posPrecedenti[i] = Convert.ToString(dito.AngMin);
            i++;
        }
        posPrecedenti[5] = Convert.ToString(bracciodx.Polso.AngDritto);

        while (true)
        { 
            try
            {

                Console.WriteLine("Inserire scelta: 0 singoli angoli, 1 posizioni preimpostate: ");
                int scelta = Convert.ToInt32(Console.ReadLine());
                if ( scelta == 0)
                { 
                    i = 0;
                    foreach (var dito in bracciodx.Mano.Dita)
                    {
                        Console.WriteLine("Inserire l'angolo del dito: " + dito.Name + " ( AngMax: " + dito.AngMax + "; AngMin: " + dito.AngMin + ") "); 
                        vetPos[i] = Console.ReadLine();

                        if ( vetPos[i] == "")
                        { 
                            vetPos[i] = posPrecedenti[i];
                        }
                        else
                        { 
                            while (Convert.ToInt32( vetPos[i]) < dito.AngMin || Convert.ToInt32( vetPos[i]) > dito.AngMax)
                            { 
                                Console.WriteLine("Valore non compreso tra massimo e minimo, reinserire il valore: "); 
                                vetPos[i] = Console.ReadLine();
                            }
                            posPrecedenti[i] =  vetPos[i];

                            dito.AngAtt = Convert.ToInt32( vetPos[i]);

                        }

                        i++;
                    }

                    Console.WriteLine("Inserire l'angolo del polso( 70 min, 160 max, 120 dritto ) : ");
                    vetPos[5] = Console.ReadLine();

                    if ( vetPos[5] == "")
                    { 
                        vetPos[5] = posPrecedenti[5];
                    }
                    else
                    {
                        while ( Convert.ToInt32( vetPos[5]) > bracciodx.Polso.AngMax || Convert.ToInt32( vetPos[5]) < bracciodx.Polso.AngMin )
                        { 
                            Console.WriteLine("Valore non compreso tra massimo e minimo, reinserire il valore: "); 
                            vetPos[5] = Console.ReadLine();
                        }
                    }

                    Utils.SerializeAndSaveBraccio(bracciodx, "Record_Angoli_DX");

                        
                }

                if ( scelta == 1 )
                { 
                    Console.WriteLine("0)Apri Mano\n1)Chiudo Mano\n2)Segno Vittoria\n3)Ok\n4)Saluto\n"); 
                    scelta = Convert.ToInt32(Console.ReadLine());

                    switch ( scelta)
                      
                    {
                        case 0: 
                            // apri mano
                            bracciodx.Mano.ApriMano();
                            break;
                        case 1:
                            // chiudi mano
                            bracciodx.Mano.ChiudiMano();
                            break;
                        case 2:
                            // segno vittoria 
                            bracciodx.Mano.Dita[0].ChiudiMin();
                            bracciodx.Mano.Dita[1].ApriMax();
                            bracciodx.Mano.Dita[2].ApriMax();
                            bracciodx.Mano.Dita[3].ChiudiMin();
                            bracciodx.Mano.Dita[4].ChiudiMin();
                                break;
                        case 3:
                                // ok
                            bracciodx.Mano.Dita[0].ApriMax();
                            bracciodx.Mano.Dita[1].ChiudiMin();
                            bracciodx.Mano.Dita[2].ChiudiMin();
                            bracciodx.Mano.Dita[3].ChiudiMin(); 
                            bracciodx.Mano.Dita[4].ChiudiMin();
                            break;
                        case 4:
                            //saluto
                            bracciodx.Mano.ApriMano();
                            break;
                        default:
                            Console.WriteLine("Comando inesistente."); 
                            break;
                    }
                    vetPos[0] = Convert.ToString(bracciodx.Mano.Dita[0].AngAtt); 
                    vetPos[1] = Convert.ToString(bracciodx.Mano.Dita[0].AngAtt); 
                    vetPos[2] = Convert.ToString(bracciodx.Mano.Dita[0].AngAtt); 
                    vetPos[3] = Convert.ToString(bracciodx.Mano.Dita[0].AngAtt); 
                    vetPos[4] = Convert.ToString(bracciodx.Mano.Dita[0].AngAtt); 
                }
                string Pos = "handdx"+String.Join(",", vetPos);
                Console.WriteLine(Pos);
                _serialPort.Write(Pos);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            
            { Console.WriteLine("Errore durante la scrittura sulla porta seriale: " + ex.Message);
            }
        }
    }
}
