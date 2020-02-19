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
     * ---- wyeliminować redundantne properties
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
        private int x;
        private int y;
        private float value;
        private Weight[] weights;

        public Perceptron(int n_x, int n_y, int height)
        {
            x = n_x;
            y = n_y;
            value = 1.0f;
            weights = new Weight[height];

            for (int y = 0; y < weights.Length; y++)
            {
                weights[y].SetY(y);
                weights[y].SetWeight(1.0f);
            }
        }

        public void SetValue(float n_value)
        {
            value = n_value;
        }

        public float GetValue()
        {
            return value;
        }

        public void SetWeight(int y, float weight)
        {
            weights[y].SetWeight(weight);
        }

        public float GetWeight(int y)
        {
            return weights[y].GetWeight();
        }

        public float[] GetWeights()
        {
            float[] r = new float[weights.Length];
            for (int y = 0; y < weights.Length; y++)
            {
                r[y] = weights[y].GetWeight();
            }
            return r;
        }

        private struct Weight
        {
            private int y;
            private float weight;

            public void SetY(int n_y)
            {
                y = n_y;
            }
            public int GetY()
            {
                return y;
            }
            public void SetWeight(float n_weight)
            {
                weight = n_weight;
            }
            public float GetWeight()
            {
                return weight;
            }
        }
    }

    
}
