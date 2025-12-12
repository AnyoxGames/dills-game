13
4372276707329
405016984354189 1761863325027039100
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 1.5668244361877441,
    "Y": -4.0614442825317383
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405009259156251:1761863323227059900",
  "next_sibling": "405025353449472:1761863326977046900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405016984591377:1761863325027093500",
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
  "aoid": "405016984723602:1761863325027124300",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405016984591377:1761863325027093500",
    "DefaultRenderer": "405016984772579:1761863325027135700",
    "DepletedRenderer": "405016984757314:1761863325027132100"
  }
},
{
  "cid": 5,
  "aoid": "405016984738437:1761863325027127800",
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
