﻿using System;
using System.Threading.Tasks;
using Hermes.Packets;

namespace Hermes
{
	public interface IClient
	{
		string Id { get; }

		bool IsConnected { get; }

		IObservable<ApplicationMessage> Receiver { get; }

		IObservable<IPacket> Sender { get; }

		Task ConnectAsync (ClientCredentials credentials, bool cleanSession = false);

		Task ConnectAsync (ClientCredentials credentials, Will will, bool cleanSession = false);

		Task SubscribeAsync (string topicFilter);

		Task SubscribeAsync (string topicFilter, QualityOfService qos);

		Task PublishAsync (ApplicationMessage message, bool retain = false);

		Task UnsubscribeAsync (params string[] topics);

		Task DisconnectAsync ();
	}
}
