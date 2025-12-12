13
4758823763969
405070775319729 1761863337560389700
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -4.3979840278625488,
    "Y": -11.9717626571655273
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405068415344968:1761863337010513100",
  "next_sibling": "405074924007158:1761863338527038300",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405070775584480:1761863337560450600",
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
  "aoid": "405070775703676:1761863337560478300",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405070775584480:1761863337560450600",
    "DefaultRenderer": "405070775756695:1761863337560490700",
    "DepletedRenderer": "405070775739624:1761863337560486700"
  }
},
{
  "cid": 5,
  "aoid": "405070775718769:1761863337560481800",
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
