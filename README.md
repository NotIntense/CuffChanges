
![Total Downloads](https://img.shields.io/github/downloads/NotIntense/CuffChanges/total)  Supported Version : ![SV](https://img.shields.io/badge/EXILED_-8.2.1-blue)

# CuffChanged

## Description

Gives server owners more customizabilty with player escapes. Allows adding roles that can escape, along with if they need to be cuffed to escape and if (and what the message should be) the player should get a escape message.

## Features

- Add new possible roles that can escape.
- Specify if the player needs to be cuffed to get the new role.
- Choose to have a custom escape message for the player.

## Installation

1. Download the latest release from the [Releases](https://github.com/NotIntense/CuffChanges/releases) page.
2. Place the `CuffChanges.dll` file into the `Exiled/Plugins` folder in your Exiled server directory.
3. Configure the plugin by editing the `config.yml` file located in the `Exiled/Configs` folder.

## Misc.

Default config : 
```CF:
  # Gets or sets if the plugin is enabled.
  is_enabled: true
  # Gets or sets if the plugin's debug logs are enabled.
  debug: false
  # Gets or sets if the player will get the custom escape message for their role change. FOR ESCAPE MESSAGES, '{newRole}' WILL BE THE NEW ROLE THE PLAYER IS SET TO.
  display_custom_escape_message: true
  # The role assigned to players upon escape based on their previous role.For Example, if a Facility Guard escapes, they'll become a NTF Private.
  role_conversion_dictionary:
    FacilityGuard:
      target_role: NtfPrivate
      need_to_be_cuffed: false
      message: 'You''ve escaped and became a {newRole}!'
