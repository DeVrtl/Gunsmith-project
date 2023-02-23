using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public Weapon Weapon { get; private set; }
    public List<Attachment> Attachments { get; private set; }

    public Order(Weapon weapon, List<Attachment> attachments)
    {
        Weapon = weapon;
        Attachments = attachments;
    }
}
