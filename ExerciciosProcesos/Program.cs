using System.Diagnostics;

class Program
{
    static void Main()
    {
        CursaCamell();
    }

    static void MostrarProcés()
    {
        // Obtenim tots els processos en execució
        Process[] processos = Process.GetProcesses();

        // Imprimim el nom i el PID de cada procés
        foreach (Process procés in processos)
        {
            Console.WriteLine($"Nom: {procés.ProcessName}, PID: {procés.Id}");
        }
    }
    static void mostrarFils()
    {
        string nomNavegador = "firefox"; // Canvia a al navegador pertinent

        // Obtenim el procés del navegador
        Process[] processos = Process.GetProcessesByName(nomNavegador);

        foreach (Process procés in processos)
        {
            Console.WriteLine($"Process: {procés.ProcessName}, PID: {procés.Id}");

            // Llistem els fils del procés
            foreach (ProcessThread fil in procés.Threads)
            {
                Console.WriteLine($"  Fil ID: {fil.Id}, Hora d'inici: {fil.StartTime}, Prioritat: {fil.PriorityLevel}");
            }
        }
    }

    static void fiveThreads()
    {
        // Creem un array per emmagatzemar els fils
        Thread[] fils = new Thread[5];

        // Creem cada fil
        for (int i = 0; i < fils.Length; i++)
        {
            int numeroFil = i + 1; // Guardem el número del fil
            fils[i] = new Thread(() => EscriureMissatge(numeroFil));
        }

        // Iniciem cada fil
        foreach (Thread fil in fils)
        {
            fil.Start();
        }
    }
    static void EscriureMissatge(int numeroFil)
    {
        int temps = 1000 * (numeroFil - 1); // Temps d'espera en milisegons
        Thread.Sleep(temps); // Cada fil espera un temps diferent
        Console.WriteLine($"Hola! Soc el fil número {numeroFil}");
    }

    static void CursaCamell()
    {
       
        Thread[] camells = new Thread[5];

        // Inicialitzem cada camell amb paràmetres aleatoris
        for (int i = 0; i < camells.Length; i++)
        {
            int numeroCamell = i + 1; // Guardem el número del camell
            int tempsMin = new Random().Next(100, 300); // Temps mínim de descans
            int tempsMax = new Random().Next(300, 500); // Temps màxim de descans

            camells[i] = new Thread(() => CursaCamell(numeroCamell, tempsMin, tempsMax));
        }

        // Iniciem cada camell
        foreach (Thread camell in camells)
        {
            camell.Start();
        }

        // Esperem que tots els camells acabin
        foreach (Thread camell in camells)
        {
            camell.Join();
        }
    }

    static void CursaCamell(int numeroCamell, int tempsMin, int tempsMax)
    {
        Random random = new Random();

        for (int i = 0; i <= 100; i++)
        {
            if(i == 100)
            {
                Console.WriteLine($"Camell {numeroCamell} ha arribat a la meta!");

            }
            else
            {
                Console.WriteLine($"Camell {numeroCamell} compta: {i}");
            }
            // Generem un temps de descans aleatori entre tempsMin i tempsMax
            int tempsDescans = random.Next(tempsMin, tempsMax);
            Thread.Sleep(tempsDescans); // El camell descansa
        }
    }
}
