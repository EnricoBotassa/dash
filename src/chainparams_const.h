// Copyright (c) 2014-2015 The Bitcoin Core developers
// Distributed under the MIT software license, see the accompanying
// file COPYING or http://www.opensource.org/licenses/mit-license.php.

#ifndef CHAINPARAMS_CONST_H
#define CHAINPARAMS_CONST_H

#include "protocol.h"

#define CONSTPARAM_TIMESTAMP "It's Zalgocoin time! He comes. 14/09/2018"
const CMessageHeader::MessageStartChars MAIN_MessageStart = { 0x4b , 0x62, 0xc7, 0xa1 };
#define CONSTPARAM_MAIN_PUB "04A65289CAB4FFAF10AC33CA4CF04052435F9EC5D153B74B37355B911B641784BD62D53A72DCC9C3D24CCC079BAE27BEEA37905DF6F06137EE6FE881442AAB5D7A"
#define CONSTPARAM_MAIN_ALERT_PUB "040982A78039B538EE4F1D26F16BACC94F12955C7C16783FF44C71C82028E9BC899C76E2FA48ACB33F95F615426C66F650A799227E7A19C7DDBF9C1EC9398733C6"
#define CONSTPARAM_MAIN_PORT 9989
const CMessageHeader::MessageStartChars TEST_MessageStart = { 0x4b , 0x62, 0xc7, 0xa1 };
#define CONSTPARAM_TEST_ALERT_PUB "04E8FFDD2963B7C9C60F22B4D366B9906DB9E976BE41F91CA2145E4EFE613D1BD388B6A89B3AE0BE67E8A94E93B458AAE1266DAF291E678A146A9B7F4E2300B628"
#define CONSTPARAM_TEST_PORT 19989
#define CONSTPARAM_REGTEST_PORT 9988
const CMessageHeader::MessageStartChars REGTEST_MessageStart = { 0x4b , 0x62, 0xc7, 0xa1 };

#define GENMAIN_TIME 1536940800
#define GENMAIN_NONCE 2067286
#define GENMAIN_BLOCK "0x00000954116059b5575d7ca01300a68687c5cd72c01b86988190edf7c9e841d5"

#define GENTEST_TIME 1536940801
#define GENTEST_NONCE 656331
#define GENTEST_BLOCK "0x000008898cc0ba858f47fa9f0769afa429dba518ac3540f5faf609775f417323"

#define GENREGTEST_TIME 1536940802
#define GENREGTEST_NONCE 5009138
#define GENREGTEST_BLOCK "0x000009e3e4b0ff5d4486a241b090b80b29b1d62932400295708b10e66b6903bc"

#define GEN_MERKLE "0x5928aa5a38f3f03fd80457a7e41a3eedc1fa1440adea3f29628b53c3e2e7caa9"

#define CONSTPARAM_GEN_REWARD 50 * COIN

#define CONSTPARAM_MAIN_RPCPORT 9979
#define CONSTPARAM_TEST_RPCPORT 19979
#define CONSTPARAM_REGTEST_RPCPORT 9978

#endif // CHAINPARAMS_CONST_H
