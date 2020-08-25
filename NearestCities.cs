/*
The cities are arranged on a graph that has been divided up like an ordinary Cartesian plane. Each city is located at an integral (x, y) coordinate intersection. City names and locations are given in the form of three arrays: c, x, and y, which are aligned by the index to provide the city name (c[i]), and its coordinates, (x[i], y[i]).

Write an algorithm to determine the name of the nearest city that shares either an x or a y coordinate with the queried city. If no other cities share an xory coordinate, return NONE. If two cities have the same distance to the queried city, q[i], consider the one with an alphabetically smaller name (i.e. 'ab' < 'aba' < 'abb') as the closest choice.

The distance is denoted on a Euclidean plane: the difference in x plus the difference in y.

Input

The input to the function/method consists of six arguments:

numOfCities, an integer representing the number of cities;

cities, a list of strings representing the names of each city [i];

xCoordinates, a list of integers representing the X coordinates of each city[i];

y Coordinates, a list of integers representing the Y-coordinates of each city[i];

numOfQueries, an integer representing the number of queries;

queries, a list of strings representing the names of the queried cities.

Output

Return a list of strings representing the name of the nearest city that shares either an x or a y coordinate with the queried city.

Constraints

1 <= numOfCities, numOfQueries < 10^ 5

1 < xCoordinates[i], yCoordinates[i] <= 10^ 9

1 < length of queries[i] and cities[i] <= 10

Note

Each character of all c[i] and q[i] is in the range ascii[a-z, 0-9,-].

All city name values, c[i], are unique. All cities have unique coordinates.

Examples

Example 1:

Input:

numOfCities = 3

cities = ["c1", "c2","c3"]

xCoordinates = [3, 2, 1]

yCoordinates = [3, 2, 3]

numOfQueries = 3

queries = ["c1", "c2", "c3"]

Output:

["c3", NONE, "c1"]

Explanation:

There are three points(3,3), (2,2) and (1,3) represent the coordinates of the cities on the graph. The nearest city to c1 is c3, which shares a y value (distance = (3-1) + (3-3) = 2).

City c2 does not have a nearest city as none share an x or y with c2, so this query returns NONE. A query of c3 returns c1 based on the first calculation. The return array after all queries are complete is [c3, NONE, c1].

 

Example 2:

Input:

numOfCities = 5

cities = ["green", "red","blue", "yellow", "pink"]

xCoordinates = [100, 200, 300, 400, 500]

yCoordinates = [100, 200, 300, 400, 500]

numOfQueries = 5

queries = ["green", "red", "blue", "yellow", "pink"]

Output

[NONE, NONE, NONE, NONE, NONE]

Explanation:

No nearest cities because none share the same x or y.  

*/


using System;
using System.IO;
using System;
using System.Collections.Generic;

namespace FindNearestCities
{
    class Program
    {
        static void Main()
        {
            String[] cities = new String[] { "London", "Tokyo", "Rome", "Toledo", "Chicago", "Athens", "Delhi" };
            int[] xC = new int[] { 1, 1, 2, 5, 4, 2, 2 };
            int[] yC = new int[] { 2, 3, 5, 4, 3, 4, 9 };
            //String[] cities = new String[] {"green", "red", "blue", "yellow", "pink"};
            //int[] xC = new int[] { 100, 200, 300, 400, 500 };
            //int[] yC = new int[] { 100, 200, 300, 400, 500 };
           
            //String[] queries = new String[] { "green", "red", "blue", "yellow", "pink" };
            String[] queries = new String[] { "London", "Delhi", "Athens" };
            findNearestCities(7, cities, xC, yC, 3, queries);
        }

        static String[] findNearestCities(int numOfCities, String[] cities, int[] xCoordinates, int[] yCoordinates, int numOfQueries, String[] queries)
        {
            Dictionary<String, int> nearest = new Dictionary<String, int>();
            String[] result = new String[numOfQueries];

            for (int i = 0; i < numOfCities; i++)
            {
                
                for (int j = i+1; j<numOfCities; j++)
                {
                    //if (j != i)
                    {
                        if (xCoordinates[i] == xCoordinates[j])
                        {
                            if (!nearest.ContainsKey(cities[i]))
                            {
                                nearest.Add(cities[i], j);
                                nearest.Add(cities[j], i);
                            }
                            else if ((yCoordinates[j] - yCoordinates[i]) < nearest[cities[i]])
                            {
                                nearest[cities[i]] = j;
                                nearest[cities[j]] = i;
                            }
                        }
                        else if (yCoordinates[i] == yCoordinates[j])
                        {
                            if (!nearest.ContainsKey(cities[i]))
                            {
                                nearest[cities[i]] = j;
                                nearest[cities[j]] = i;
                            }

                            if ((xCoordinates[j] - xCoordinates[i]) < nearest[cities[i]])
                            {
                                nearest[cities[i]] = j;
                                nearest[cities[j]] = i;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < numOfQueries; i++)
            {
                if (!nearest.ContainsKey(queries[i]))
                    result[i] = "NONE";
                else
                    result[i] = cities[nearest[queries[i]]];
            }
            return result;
        }

    }
}