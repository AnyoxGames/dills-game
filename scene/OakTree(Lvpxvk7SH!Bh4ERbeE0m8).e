13
4355096838145
3305803839943815 1763178044028307900
{
  "name": "OakTree",
  "local_enabled": true,
  "local_position": {
    "X": 16.2535018920898438,
    "Y": 9.4110946655273438
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "3305800263276146:1763178043194943700",
  "next_sibling": "3305807487944297:1763178044878293800",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "OakTree.prefab"
},
{
  "cid": 3,
  "aoid": "3305803840254877:1763178044028380300",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Oak Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 5,
  "aoid": "3305803840277108:1763178044028385500",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
},
{
  "cid": 1,
  "aoid": "3305803840307251:1763178044028392500",
  "component_type": "Mono_Component",
  "mono_component_type": "OakTree",
  "data": {
    "Interactable": "3305803840254877:1763178044028380300",
    "DefaultRenderer": "3305803840340662:1763178044028400300",
    "DepletedRenderer": "3305803840327332:1763178044028397100"
  }
}
