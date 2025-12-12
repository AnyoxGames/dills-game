13
4801773436929
405079073661787 1761863339493912500
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -1.5545454025268555,
    "Y": -12.1855554580688477
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405074924007158:1761863338527038300",
  "next_sibling": "405080504266670:1761863339827244600",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405079074036231:1761863339493998400",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "405079074191891:1761863339494034700",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405079074036231:1761863339493998400",
    "DefaultRenderer": "405079074246759:1761863339494047500",
    "DepletedRenderer": "405079074229086:1761863339494043300"
  }
},
{
  "cid": 5,
  "aoid": "405079074208790:1761863339494038600",
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
}
