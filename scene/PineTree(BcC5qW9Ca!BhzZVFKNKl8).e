13
3126736191489
404819631919258 1761863279043717500
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 3.1488814353942871,
    "Y": 9.4502372741699219
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404815411404757:1761863278060333500",
  "next_sibling": "404823066083985:1761863279843881700",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404819632156618:1761863279043771900",
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
  "aoid": "404819632283898:1761863279043801600",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404819632156618:1761863279043771900",
    "DefaultRenderer": "404819632331542:1761863279043812700",
    "DepletedRenderer": "404819632315288:1761863279043808900"
  }
},
{
  "cid": 5,
  "aoid": "404819632295594:1761863279043804300",
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
