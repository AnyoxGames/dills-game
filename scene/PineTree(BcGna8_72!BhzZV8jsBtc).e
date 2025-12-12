13
4780298600449
405074924007158 1761863338527038300
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -2.8586783409118652,
    "Y": -12.2924509048461914
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405070775319729:1761863337560389700",
  "next_sibling": "405079073661787:1761863339493912500",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405074924264513:1761863338527097300",
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
  "aoid": "405074924385558:1761863338527125500",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405074924264513:1761863338527097300",
    "DefaultRenderer": "405074924438663:1761863338527137900",
    "DepletedRenderer": "405074924420087:1761863338527133600"
  }
},
{
  "cid": 5,
  "aoid": "405074924400608:1761863338527129000",
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
