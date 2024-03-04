﻿using System;
using System.Collections.Generic;

namespace PetShop.Business.Models;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? OrderDate { get; set; }

    public bool? Status { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
