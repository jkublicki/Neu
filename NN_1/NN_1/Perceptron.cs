using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    /*
     * ### Ogólne uwagi ###
     * - access: może zamiast miliona metod dostępowych do private, można by to ograć public, readonly itp. 
     * -- ale może jest jakas korzyść z obecnego podejścia
     * --- powinno to zostać przerobiona na properties: https://www.w3schools.com/cs/cs_properties.asp
     * ---- decyzja o access / uzyciu properties: https://stackoverflow.com/questions/4142867/what-is-the-difference-between-a-property-and-a-variable
     * ----- mieć zmienne prywatne, gety i sety
     * ---- wyeliminować redundantne properties
     * 
     * --random float i floats equal powinny wylecieć do toolsów
     * 
     * --niedokończone zastępowanie pojęcia Perceptron.Value pojęciem Perceptron.Output
     * 
     * - TODO w klasach metody powinny mieć walidację parametrów po wywołaniu, np. czy indeks wykracza
     * -- rzucać błędy i w ich treści aktualne argumenty dla których funkcja się wykrzaczyła
     * //- interfejs: chciałbym mieć uniwersalną klasę bazową network, nad nią specyficzną network-typ-x-specyficzną funkcją, 
     * //-- a wyżej znowu uniwersalny kalkulator, manager ds. jednego testu, manager wielu testów, zarządzanie wagami
     * 
     * - struct Weight jest niefortunna, wystarczyłoby float[];
     * //- outputy nie mają wag! powinny po prostu być perceptronami, ale na innej liście w Network (najpierw wywalić struct)
     *  
     * - WAŻNE - RAM przy wymiarach 1000x1000 jest out of memory exception na samym tworzeniu sieci
     * -- wrócić do shortów, ale jak je dodawać? chyba można nawet jakoś pokracznie, bo rzadko się to robi
     * 
     * - niekonsekwentne nazewnictwo - GetEntity() - oznacza referencję czy wartość? wszystkim funkcjom do wartości dodać sufix value
     * - redundantny zestaw funkcji chyba
     * 
     * - chyba błędnie zakładam, że wysokość macierzy inputów będzie zawsze równa wysokości macierzy neuronów - doczytać jak się robi
     * -- mniejsza
     * -- większa?
     * 
     * -- jak organizuje się projekty? namespace, foldery?
     * 
     * 
     * ### Status 18.02.2020 ###
     * - działa! w Test.cs udało się uczenie funkcji AND, OR, XOR na sieci (1 x 2)
     * -- dla AND jakieś 30% szans sukcesu per klik przy 100000
     * -- dla OR b. szybko
     * -- dla XOR jakieś 5% szans per klik przy 100000
     * 
     * - widać, że brakuje b. wielu warstw jeszcze
     * 
     * 
     */

    public class Perceptron
    {
        private float output; //ignorować odpowiedź o property, wynika z tego, że get i set są (póki co!) trywialne
        public float Output
        { get { return output; } set { output = value; } }

        //klasa konsumująca musi zadbać o zgodność indeksu Weights ze swoim indeksem neuronów
        //przykład:
        //sieć ma X warstw po Y neuronów; obliczając wartość neuronu na pozycji (x1, y1) 
        //iterujemy po neuronach od (x1 - 1, 0) do (x1 - 1, Y - 1) aby uzyskać ich Value
        //i jednocześnie tą samą zmienną iteracyjną po Weights od 0 do Y - 1
        private float[] weights;
        public float[] Weights 
        { get { return weights; } set { Array.Copy(value, weights, weights.Length); } }

        public Perceptron(int weightsLength)
        {
            output = 1.0f;
            weights = new float[weightsLength];
            for (int y = 0; y < weightsLength; y++)
            {
                weights[y] = 1.0f;
            }
        }
    }

    
}
