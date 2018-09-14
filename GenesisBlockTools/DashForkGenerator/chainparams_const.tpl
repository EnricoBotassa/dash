// Copyright (c) 2014-2015 The Bitcoin Core developers
// Distributed under the MIT software license, see the accompanying
// file COPYING or http://www.opensource.org/licenses/mit-license.php.

#ifndef CHAINPARAMS_CONST_H
#define CHAINPARAMS_CONST_H

#include "protocol.h"

#define CONSTPARAM_TIMESTAMP "%zsvTimestamp%"
const CMessageHeader::MessageStartChars MAIN_MessageStart = { %main_hex1% , %main_hex2%, %main_hex3%, %main_hex4% };
#define CONSTPARAM_MAIN_PUB "%main_pub%"
#define CONSTPARAM_MAIN_ALERT_PUB "%main_alert_pub%"
#define CONSTPARAM_MAIN_PORT %main_port%
const CMessageHeader::MessageStartChars TEST_MessageStart = { %test_hex1% , %test_hex2%, %test_hex3%, %test_hex4% };
#define CONSTPARAM_TEST_ALERT_PUB "%test_alert_pub%"
#define CONSTPARAM_TEST_PORT %test_port%
#define CONSTPARAM_REGTEST_PORT %regtest_port%
const CMessageHeader::MessageStartChars REGTEST_MessageStart = { %regtest_hex1% , %regtest_hex2%, %regtest_hex3%, %regtest_hex4% };

#define GENMAIN_TIME %main_timestamp%
#define GENMAIN_NONCE %main_nonce%
#define GENMAIN_BLOCK "0x%main_hash%"

#define GENTEST_TIME %test_timestamp%
#define GENTEST_NONCE %test_nonce%
#define GENTEST_BLOCK "0x%test_hash%"

#define GENREGTEST_TIME %regtest_timestamp%
#define GENREGTEST_NONCE %regtest_nonce%
#define GENREGTEST_BLOCK "0x%regtest_hash%"

#define GEN_MERKLE "0x%merkle_hash%"

#define CONSTPARAM_GEN_REWARD 50 * COIN

#define CONSTPARAM_MAIN_RPCPORT %main_rpc%
#define CONSTPARAM_TEST_RPCPORT %test_rpc%
#define CONSTPARAM_REGTEST_RPCPORT %regtest_rpc%

#endif // CHAINPARAMS_CONST_H
