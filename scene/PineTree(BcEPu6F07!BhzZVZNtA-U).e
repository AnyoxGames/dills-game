13
3642132267009
404912050036027 1761863300577234900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -13.8048505783081055,
    "Y": -6.6483321189880371
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404904038245470:1761863298710480500",
  "next_sibling": "404914195960854:1761863301077237200",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404912050435927:1761863300577326700",
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
  "aoid": "404912050592576:1761863300577363200",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404912050435927:1761863300577326700",
    "DefaultRenderer": "404912050672384:1761863300577381900",
    "DepletedRenderer": "404912050644778:1761863300577375300"
  }
},
{
  "cid": 5,
  "aoid": "404912050613345:1761863300577368000",
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
