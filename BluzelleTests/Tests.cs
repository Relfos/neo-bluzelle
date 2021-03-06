﻿using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using Neo.Lux.Core;
using Neo.Lux.Utils;
using Neo.Lux.Cryptography;
using System.Diagnostics;
using System.Numerics;
using Neo.Lux.Debugger;
using Bluzelle.NEO.Contract;
using Bluzelle.NEO.Sharp.Core;

namespace Bluzelle.NEO.Tests
{
    public class TestEnviroment
    {
        public readonly Emulator api;
        public readonly KeyPair owner_keys;
        public readonly KeyPair admin_keys;
        public readonly DebugClient debugger;
        public readonly ISwarm swarm;

        public TestEnviroment()
        {
            debugger = new DebugClient();

            // this is the key for the NEO "issuer" in the virtual chain used for testing
            owner_keys = KeyPair.GenerateAddress();

            this.api = new Emulator(owner_keys);

            this.api.SetLogger(x => {
                if (api.Chain.HasDebugger)
                {
                    debugger.WriteLine(x);
                }
                Debug.WriteLine(x);
            });

            this.swarm = new TestSwarm();

            Transaction tx;

            // create a random key for the team
            admin_keys = KeyPair.GenerateAddress();

            // since the real admin address is hardcoded in the contract, use BypassKey to give same permissions to this key
            this.api.Chain.BypassKey(new UInt160(BluzelleContract.Admin_Address), new UInt160(admin_keys.address.AddressToScriptHash()));

            tx = api.SendAsset(owner_keys, admin_keys.address, "GAS", 800);
            Assert.IsNotNull(tx);

            var balances = api.GetAssetBalancesOf(admin_keys.address);
            Assert.IsTrue(balances.ContainsKey("GAS"));
            Assert.IsTrue(balances["GAS"] == 800);

            tx = api.DeployContract(admin_keys, ContractTests.contract_script_bytes, "0710".HexToBytes(), 5, ContractPropertyState.HasStorage, "Bluzelle", "1.0", "http://bluzelle.com", "info@bluzelle.com", "Bluzelle Smart Contract");
            Assert.IsNotNull(tx);
        }
    }

    [TestClass]
    public class ContractTests
    {
        public static byte[] contract_script_bytes { get; set; }
        public static UInt160 contract_script_hash { get; set; }

        private string contract_folder;

        [TestInitialize]
        public void FixtureSetUp()
        {
            //var temp = TestContext.CurrentContext.TestDirectory.Split(new char[] { '\\', '/' }).ToList();
            var contract_folder = Directory.GetCurrentDirectory().Replace("BluzelleTests", "Bluzelle.NEO.Contract");

            Console.WriteLine("Loading contract at " + contract_folder);

            contract_script_bytes = File.ReadAllBytes(contract_folder + "/BluzelleContract.avm");
            contract_script_hash = contract_script_bytes.ToScriptHash();

            Assert.IsNotNull(contract_script_bytes);
        }

        [TestMethod]
        public void TestCore()
        {
            var env = new TestEnviroment();

            var test_keypair = KeyPair.GenerateAddress();

            env.api.SendAsset(env.owner_keys, test_keypair.address,  "GAS", 1);

            var test_key = "test_key";
            var test_value = "Hello world!";

            var bridge = new BridgeManager(env.api, env.swarm, env.admin_keys.WIF, contract_script_bytes, env.api.GetBlockHeight());

            var tx = env.api.CallContract(test_keypair, contract_script_hash, "create", new object[] { test_keypair.address.AddressToScriptHash(), test_key, test_value });

            /*Assert.IsNotNull(tx);

            env.api.WaitForTransaction(test_keypair, tx);

            // run for a single block
            bridge.Run(1);
            
            env.swarm.Read(env.ui)*/
        }
    }
}
