using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos

        string id; // identificador
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        Position initialPosition; //Posición inicial
        double velocidad;

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = this.initialPosition;
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }

        

        // Metodos

        public void SetVelocidad(double velocidad)
        // setter del atributo velocidad
        { this.velocidad = velocidad; }

        public string GetID()
        {
            return this.id;
        }



        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            //Modificar Mover vuelo para que no se pase del destino
            Position nextPosition = new Position(x, y);

            if (currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;
            
        }
        // Indicador de si un vuelo ha llegado a su destino
        public bool DestinoFinal()
        {
            bool found = false;
            if (currentPosition == finalPosition)
                found = true;

            return found;
        }

        //Hacer un método que detecte si dos vuelos están demasiado cerca

        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool res = false;

            if (this.currentPosition.Distancia(b.currentPosition) < distanciaSeguridad)
                res = true;

            return res;
        }

        public bool Restart() // Si no ha habido error, reinicia la posición del vuelo
        {
            try
            {
                this.currentPosition = this.initialPosition;
                return true;
            }
            catch
            {
                return false;
            }

        }
        
        public double Distance(FlightPlan plan) //Devuelve la distancia de este plan de vuelo al plan proporcionado como parámetro
        {
            try
            {
                double X = this.currentPosition.GetX() - plan.currentPosition.GetX();
                double Y = this.currentPosition.GetY() - plan.currentPosition.GetY();

                double distance = Math.Sqrt(X * X + Y * Y);

                return distance;
            }
            catch
            {
                return 0.0;
            }
        }

        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            // Escribir datos reales con solo dos decimales
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2}, {1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.DestinoFinal())
                Console.WriteLine("Ha llegado al destino");
            Console.WriteLine("******************************");
        }
    }
}
