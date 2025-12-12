13
4329327034369
405009259156251 1761863323227059900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 7.3819785118103027,
    "Y": -9.8338384628295898
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405007184708670:1761863322743711600",
  "next_sibling": "405016984354189:1761863325027039100",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405009259402813:1761863323227116500",
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
  "aoid": "405009259532114:1761863323227146700",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405009259402813:1761863323227116500",
    "DefaultRenderer": "405009259581564:1761863323227158200",
    "DepletedRenderer": "405009259566084:1761863323227154600"
  }
},
{
  "cid": 5,
  "aoid": "405009259545057:1761863323227149700",
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
