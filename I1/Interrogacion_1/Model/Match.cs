using System.Collections.Generic;

namespace Interrogacion_1.Model
{
    class Match
    {
        public List<INadeje> peliculas = new List<INadeje> { };
        public HashSet<string> nombre_peliculas = new HashSet<string>();
        public List<INadeje> Main_match_peliculas(Critics_metacritics peliculas_metacritics, Critics_rotten peliculas_rotten, Movies_imdb peliculas_imdb)
        {
            Triple_match(peliculas_metacritics, peliculas_rotten, peliculas_imdb);
            Match_metacritics_rotten(peliculas_metacritics, peliculas_rotten);
            Match_metacritics_imdb(peliculas_metacritics, peliculas_imdb);
            Match_rotten_imdb(peliculas_rotten, peliculas_imdb);
            Match_rotten(peliculas_rotten);
            Match_imdb(peliculas_imdb);
            Match_metacritics(peliculas_metacritics);

            return peliculas;
        }
        public void Triple_match(Critics_metacritics peliculas_metacritics, Critics_rotten peliculas_rotten, Movies_imdb peliculas_imdb)
        {
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
        }
        public void Match_metacritics_rotten(Critics_metacritics peliculas_metacritics, Critics_rotten peliculas_rotten)
        {
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
        }
        public void Match_metacritics_imdb(Critics_metacritics peliculas_metacritics, Movies_imdb peliculas_imdb)
        {
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
        }
        public void Match_rotten_imdb(Critics_rotten peliculas_rotten, Movies_imdb peliculas_imdb)
        {
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
        }
        public void Match_rotten(Critics_rotten peliculas_rotten)
        {
            for (int j = 0; j < peliculas_rotten.Critics.Count; j++)
            {
                if (!nombre_peliculas.Contains(peliculas_rotten.Critics[j].Title.ToUpper()))
                {
                    Nadeje_adapter adapter = new Nadeje_adapter(peliculas_rotten.Critics[j].Title, null, null, peliculas_rotten.Critics[j]);
                    peliculas.Add(adapter);
                    nombre_peliculas.Add(peliculas_rotten.Critics[j].Title.ToUpper());
                }
            }
        }
        public void Match_imdb(Movies_imdb peliculas_imdb)
        {
            for (int k = 0; k < peliculas_imdb.Movies.Count; k++)
            {
                if (!nombre_peliculas.Contains(peliculas_imdb.Movies[k].Name.ToUpper()))
                {
                    Nadeje_adapter adapter = new Nadeje_adapter(peliculas_imdb.Movies[k].Name, peliculas_imdb.Movies[k], null, null);
                    peliculas.Add(adapter);
                    nombre_peliculas.Add(peliculas_imdb.Movies[k].Name.ToUpper());
                }
            }
        }
        public void Match_metacritics(Critics_metacritics peliculas_metacritics)
        {
            for (int i = 0; i < peliculas_metacritics.Critics.Count; i++)
            {
                if (!nombre_peliculas.Contains(peliculas_metacritics.Critics[i].Name.ToUpper()))
                {
                    Nadeje_adapter adapter = new Nadeje_adapter(peliculas_metacritics.Critics[i].Name, null, peliculas_metacritics.Critics[i], null);
                    peliculas.Add(adapter);
                    nombre_peliculas.Add(peliculas_metacritics.Critics[i].Name.ToUpper());
                }
            }
        }
    }
}
