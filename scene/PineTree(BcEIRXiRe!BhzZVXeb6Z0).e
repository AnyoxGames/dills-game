13
3620657430529
404904038245470 1761863298710480500
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -15.2372608184814453,
    "Y": -5.3014402389526367
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404901534384028:1761863298127076700",
  "next_sibling": "404912050036027:1761863300577234900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404904038527292:1761863298710543800",
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
  "aoid": "404904038649068:1761863298710572100",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404904038527292:1761863298710543800",
    "DefaultRenderer": "404904038700410:1761863298710584000",
    "DepletedRenderer": "404904038682651:1761863298710579900"
  }
},
{
  "cid": 5,
  "aoid": "404904038661194:1761863298710574900",
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
