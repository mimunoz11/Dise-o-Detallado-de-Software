using System;
using System.Collections.Generic;

namespace Interrogacion_1.Model
{
    class Match
    {
        public List<INadeje> Match_peliculas(Critics_metacritics peliculas_metacritics, Critics_rotten peliculas_rotten, Movies_imdb peliculas_imdb)
        {
            List<INadeje> peliculas = new List<INadeje> { };
            // HashSet
            var nombre_peliculas = new HashSet<string>();
            for (int i = 0; i < peliculas_metacritics.Critics.Count; i++)
            {
                for (int j = 0; j < peliculas_rotten.Critics.Count; j++)
                {
                    if (peliculas_metacritics.Critics[i].Name.ToUpper() == peliculas_rotten.Critics[j].Title.ToUpper())
                    {
                        for (int k = 0; k < peliculas_imdb.Movies.Count; k++)
                        {
                            if (peliculas_metacritics.Critics[i].Name.ToUpper() == peliculas_imdb.Movies[k].Name.ToUpper())
                            {
                                Nadeje_adapter adapter = new Nadeje_adapter(peliculas_metacritics.Critics[i].Name, peliculas_imdb.Movies[k], peliculas_metacritics.Critics[i], peliculas_rotten.Critics[j]);
                                peliculas.Add(adapter);
                                nombre_peliculas.Add(peliculas_metacritics.Critics[i].Name.ToUpper());
                            }
                        }
                    }
                }
            }


            for (int i = 0; i < peliculas_metacritics.Critics.Count; i++)
            {
                for (int j = 0; j < peliculas_rotten.Critics.Count; j++)
                {
                    if (peliculas_metacritics.Critics[i].Name.ToUpper() == peliculas_rotten.Critics[j].Title.ToUpper() && !nombre_peliculas.Contains(peliculas_metacritics.Critics[i].Name.ToUpper()))
                    {
                        Nadeje_adapter adapter = new Nadeje_adapter(peliculas_metacritics.Critics[i].Name, null, peliculas_metacritics.Critics[i], peliculas_rotten.Critics[j]);
                        peliculas.Add(adapter);
                        nombre_peliculas.Add(peliculas_metacritics.Critics[i].Name.ToUpper());
                    }
                }
            }



            for (int j = 0; j < peliculas_rotten.Critics.Count; j++)
            {
                for (int k = 0; k < peliculas_imdb.Movies.Count; k++)
                {
                    if (peliculas_rotten.Critics[j].Title.ToUpper() == peliculas_imdb.Movies[k].Name.ToUpper() && !nombre_peliculas.Contains(peliculas_imdb.Movies[k].Name.ToUpper()))
                    {
                        Nadeje_adapter adapter = new Nadeje_adapter(peliculas_imdb.Movies[k].Name, peliculas_imdb.Movies[k], null, peliculas_rotten.Critics[j]);
                        peliculas.Add(adapter);
                        nombre_peliculas.Add(peliculas_imdb.Movies[k].Name.ToUpper());
                    }
                }
            }

            for (int i = 0; i < peliculas_metacritics.Critics.Count; i++)
            {
                for (int k = 0; k < peliculas_imdb.Movies.Count; k++)
                {
                    if (peliculas_metacritics.Critics[i].Name.ToUpper() == peliculas_imdb.Movies[k].Name.ToUpper() && !nombre_peliculas.Contains(peliculas_metacritics.Critics[i].Name.ToUpper()))
                    {
                        Nadeje_adapter adapter = new Nadeje_adapter(peliculas_metacritics.Critics[i].Name, peliculas_imdb.Movies[k], peliculas_metacritics.Critics[i], null);
                        peliculas.Add(adapter);
                        nombre_peliculas.Add(peliculas_metacritics.Critics[i].Name.ToUpper());
                    }
                }
            }

            for (int i = 0; i < peliculas_metacritics.Critics.Count; i++)
            {
                if (!nombre_peliculas.Contains(peliculas_metacritics.Critics[i].Name.ToUpper()))
                {
                    Nadeje_adapter adapter = new Nadeje_adapter(peliculas_metacritics.Critics[i].Name, null, peliculas_metacritics.Critics[i], null);
                    peliculas.Add(adapter);
                    nombre_peliculas.Add(peliculas_metacritics.Critics[i].Name.ToUpper());
                }
            }

            for (int j = 0; j < peliculas_rotten.Critics.Count; j++)
            {
                if (!nombre_peliculas.Contains(peliculas_rotten.Critics[j].Title.ToUpper()))
                {
                    Nadeje_adapter adapter = new Nadeje_adapter(peliculas_rotten.Critics[j].Title, null, null, peliculas_rotten.Critics[j]);
                    peliculas.Add(adapter);
                    nombre_peliculas.Add(peliculas_rotten.Critics[j].Title.ToUpper());
                }
            }

            for (int k = 0; k < peliculas_imdb.Movies.Count; k++)
            {
                if (!nombre_peliculas.Contains(peliculas_imdb.Movies[k].Name.ToUpper()))
                {
                    Nadeje_adapter adapter = new Nadeje_adapter(peliculas_imdb.Movies[k].Name, peliculas_imdb.Movies[k], null, null);
                    peliculas.Add(adapter);
                    nombre_peliculas.Add(peliculas_imdb.Movies[k].Name.ToUpper());
                }
            }


            return peliculas;
        }
    }
}
