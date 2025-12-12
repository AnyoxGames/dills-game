13
1730871820290
367519923823901 1761854588173125200
{
  "name": "Iron",
  "local_enabled": true,
  "local_position": {
    "X": -3.5010986328125000,
    "Y": -2.8598632812500000
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "next_sibling": "367519924794884:1761854588173351400",
  "parent": "365926201346585:1761854216834139500",
  "spawn_as_networked_entity": true,
  "linked_prefab": "Iron.prefab"
},
{
  "cid": 2,
  "aoid": "367519923941721:1761854588173152600",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Iron Ore",
    "hold_text": "Harvesting..",
    "radius": 1.5000000000000000,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 1,
  "aoid": "367519923952342:1761854588173155100",
  "component_type": "Mono_Component",
  "mono_component_type": "IronOre",
  "data": {
    "Interactable": "367519923941721:1761854588173152600",
    "DefaultRenderer": "367519923961071:1761854588173157100",
    "DepletedRenderer": "367519923929079:1761854588173149700"
  }
}
