﻿using System;
using System.Collections.Generic;
using System.Text;
// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
	public enum OrderStatusId : long
	{
		Pending,
		AwaitingPayment,
		ConfirmedPayment,
		AwaitingShipment,
		Completed,
		Cancelled,
		Declined,
		Refunded
	}
}
