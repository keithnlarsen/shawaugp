using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
	public class ItemComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
		where PropertyType : IComparable<PropertyType>
    {
		private readonly Func<ItemToCompare, PropertyType> accessor;

		public ItemComparer(Func<ItemToCompare, PropertyType> accessor)
		{
			this.accessor = accessor;
		}

		public int Compare(ItemToCompare x, ItemToCompare y)
        {
			return accessor(x).CompareTo(accessor(y));
        }
    }

    public class ListComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
        where PropertyType : IComparable<PropertyType>
    {
        private readonly Func<ItemToCompare, PropertyType> accessor;
        private PropertyType[] order;

        public ListComparer(Func<ItemToCompare, PropertyType> accessor, PropertyType[] order)
        {
            this.order = order;
            this.accessor = accessor;
        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            int positionX = get_position(x);
            int positionY = get_position(y);

            return positionX - positionY;
        }

        private int get_position(ItemToCompare x)
        {
            for (int i = 0; i < order.Length; i++)
            {
                if (order[i].Equals(accessor(x)))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}