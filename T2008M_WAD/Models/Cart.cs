using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T2008M_WAD.Models
{
    public class Cart
    {
        private List<CartItem> cartItems;
        private int grandTotal;

        public Cart()
        {
            cartItems = new List<CartItem>();
        }
        public int GrandTotal { get => grandTotal; set => grandTotal = value; }
        public List<CartItem> CartItems { get => cartItems; }
        public CartItem this[int index]
        {
            get => CartItems[index];
            set => CartItems[index] = value;
        }
        public void AddToCart(CartItem cartItem)
        {
            int position = CheckExists(cartItem);
            if (position >= 0)
            {
                CartItems[position].Qty += cartItem.Qty;
            }
            else
            {
                CartItems.Add(cartItem);
            }
            CalculateGrandTotal();
        }
        public void RemoveItem(int id)
        {
            foreach (var item in CartItems)
            {
                if (item.Product.Id == id)
                {
                    CartItems.Remove(item);
                    break;
                }
            }
            CalculateGrandTotal();
        }
        public void CalculateGrandTotal()
        {
            int grand = 0;
            foreach (var item in CartItems)
            {
                grand += item.Product.Price * item.Qty;
            }
            grandTotal = grand;
        }
        private int CheckExists(CartItem cartItem)
        {
            int i = 0;
            foreach (CartItem item in CartItems)
            {
                if (cartItem.Product.Id == item.Product.Id)
                {
                    return i;
                }
                i++;
            }
            return i = -1;
        }
    }
}