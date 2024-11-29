﻿using FakeLab.Exceptions;
using FakeLab.Resources;

namespace FakeLab
{
    internal static class ArrayConverter
    {
        internal static object[] CreateObjectArray(Type collectionType, int length, Func<Type, object> getElement)
        {
            var array = new object[length];

            for (int i = 0; i < length; i++)
                array[i] = getElement(collectionType.GetElementType()!);

            return array;
        }

        internal static object[,] CreateObjectMatrix(Type collectionType, int rows, int cols, Func<Type, object> getElement)
        {
            var matrix = new object[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = getElement(collectionType.GetElementType()!);

            return matrix;
        }

        internal static TObject[,] ConvertToTypedArray<TObject>(object[,] sourceArray)
        {
            int rows = sourceArray.GetLength(0);
            int cols = sourceArray.GetLength(1);

            TObject[,] typedArray = new TObject[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    object value = sourceArray[i, j];

                    if (value is TObject typedValue)
                    {
                        typedArray[i, j] = typedValue;
                    }
                    else
                    {
                        throw new CastException(Error.CastError, i.ToString(), j.ToString(), value?.GetType().FullName!, typeof(TObject).FullName!);
                    }
                }
            }

            return typedArray;
        }
    }
}