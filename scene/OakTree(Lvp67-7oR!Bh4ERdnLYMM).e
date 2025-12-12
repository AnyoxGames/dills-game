13
5050881540097
3305813712026129 1763178046328505100
{
  "name": "OakTree",
  "local_enabled": true,
  "local_position": {
    "X": 16.2083072662353516,
    "Y": 2.2253417968750000
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "3305810134399123:1763178045494917200",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "OakTree.prefab"
},
{
  "cid": 3,
  "aoid": "3305813712474791:1763178046328609400",
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
  "aoid": "3305813712494614:1763178046328614000",
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
  "aoid": "3305813712524929:1763178046328621100",
  "component_type": "Mono_Component",
  "mono_component_type": "OakTree",
  "data": {
    "Interactable": "3305813712474791:1763178046328609400",
    "DefaultRenderer": "3305813712557050:1763178046328628500",
    "DepletedRenderer": "3305813712544580:1763178046328625600"
  }
}
