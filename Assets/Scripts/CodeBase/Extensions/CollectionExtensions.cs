using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Extensions
{
    public static class CollectionExtensions
    {
        public static T GetRandomElement<T>(this IEnumerable<T> collection)
            => collection.ElementAt(UnityEngine.Random.Range(0, collection.Count()));


        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            System.Random random = new System.Random();

            return source.ShuffleIterator(random);
        }

        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, System.Random random)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = random.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}
