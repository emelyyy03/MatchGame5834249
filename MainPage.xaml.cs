namespace MatchGame5834249
{
    public partial class MainPage : ContentPage
    {
        //Interfaz de tipo dispatchertime 
        IDispatcherTimer timer;
        //variable de tipo entero que declara los milisegundos
        int milisegundos;
        //variable de tipo entero que declara los pares
        int pares;
        
        public MainPage()
        {
            //Crear el temporizador
            timer = Dispatcher.CreateTimer();
            //declarar el inicio del temporizador desde el primer milisegundo en que se abre la aplicacion
            timer.Interval = TimeSpan.FromSeconds(.1);
            //para declarar el control de ticks del temporizador
            timer.Tick += Timer_Tick;
            //Inicializar el programa
            InitializeComponent();
            //Evento para llevar a cabo el juego
            SetUpGame();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            //Para increment los milisegundos
            milisegundos++;
            //Label que muestra los milisegundos que tarda en terminar el juego
            labelTime.Text=(milisegundos/10f).ToString("0.00s");
            //si el juego a terminado..
            if (pares == 8)
            {
                //se detiene el temporizador
                timer.Stop();
                //El label muestra texto de que el juego ha terminado
                labelTime.Text = labelTime.Text + " - Ha finalizado el juego.";
                //El boton de reiniciar juego se vuelve visible
                BtnReiniciar.IsVisible = true;
            }
        }

        //Evento para llevar a cabo el juego
        private void SetUpGame()
        {
            //Crear una lista con los emojis que se mostraran en el juego
            List<string> animalEmoji = new List<string>()
            {
                "🐶","🐶",
                "🙈","🙈",
                "🦑","🦑",
                "🐘","🐘",
                "🦓","🦓",
                "🦕","🦕",
                "🐍","🐍",
                "🐬","🐬",
            };

            //Crear una instancia de la clase Random del programa
            Random random = new Random();

            //Imprimir en cada espacio del grid que sea un botón
            foreach(Button view in Gri1.Children )
            {
                //Para que los botones sean visibles
                view.IsVisible = true;
                //se declara para que las pocisiones de los objetos sean aleatorios
                int index = random.Next( animalEmoji.Count );
                //Se declra una variable para asignar los emojis a un indice
                string nextEmoji = animalEmoji[index];
                //Para visualizar el emoji en el botón
                view.Text = nextEmoji;
                //Se borran los botones pares selccionados en el juego
                animalEmoji.RemoveAt(index);
            }

            //Se inicia el temporizador con milisegundos y pares en 0
            timer.Start(); 
            milisegundos = 0;
            pares = 0;  

        }


        //Variable para guadr el ltimo boton usado
        Button ultimoButtonCliked;
        //Variable para encontrar los pares
        bool encontrandoMatch = false;

        //Evento que se ejecutara al dar click en el boton..
        private void Button_Clicked(object sender, EventArgs e)
        {
            //Guardar la accion en una variabl de tipo Botón
            Button button = sender as Button;
            //Si al dar clic en un boton la vaiable es falsa..
           if ( encontrandoMatch == false)
            {
                //El boton se vuelve invisible
                button.IsVisible = false;
                //Gurdar el boton en una variable
                ultimoButtonCliked = button;
                //Cambiar el estado de la variable a verdadero
                encontrandoMatch= true;
            }
           //Si el siguinte boton coincide con el boton anterior, entonces..
           else if (button.Text==ultimoButtonCliked.Text)
            {
                //Incrementar los pares
                pares++;
                //Los botones se vuelven invisibles
                button.IsVisible = false;
                //Cambir el estado de la variable a falsa
                encontrandoMatch = false;
            }
           //Si los botones no coinciden...
           else
            {
                //el ultimo boton seleccionado se vuelve visible de nuevo
                ultimoButtonCliked.IsVisible = true;
                //Cambia rel estado de la varible a falso
                encontrandoMatch = false;
            }

        }

        //Evento del boton que se llevara a cabo al tocar el boton de reiniciar
        private void BtnReiniciar_Clicked(object sender, EventArgs e)
        {
            //Reiniciar el evento para llevar a cabo el juego
            SetUpGame();
            //El boton de reiniciar se vuelve invisible al volver  iniciar el juego
            BtnReiniciar.IsVisible = false;
        }
    }

}
