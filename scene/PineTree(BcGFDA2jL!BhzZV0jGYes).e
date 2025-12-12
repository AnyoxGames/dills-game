13
4544075399169
405038015146187 1761863329927235500
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 14.9502277374267578,
    "Y": -11.1593513488769531
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405036083831244:1761863329477237400",
  "next_sibling": "405039802729544:1761863330343744200",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405038015511902:1761863329927319700",
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
  "aoid": "405038015668121:1761863329927356200",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405038015511902:1761863329927319700",
    "DefaultRenderer": "405038015748918:1761863329927375000",
    "DepletedRenderer": "405038015721742:1761863329927368600"
  }
},
{
  "cid": 5,
  "aoid": "405038015690008:1761863329927361200",
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
