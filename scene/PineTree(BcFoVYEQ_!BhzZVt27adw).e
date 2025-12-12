13
4307852197889
405007184708670 1761863322743711600
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 5.7785353660583496,
    "Y": -10.7745256423950195
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404991949140405:1761863319193808400",
  "next_sibling": "405009259156251:1761863323227059900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405007184941214:1761863322743764800",
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
  "aoid": "405007185064237:1761863322743793500",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405007184941214:1761863322743764800",
    "DefaultRenderer": "405007185114203:1761863322743805200",
    "DepletedRenderer": "405007185096487:1761863322743801000"
  }
},
{
  "cid": 5,
  "aoid": "405007185076578:1761863322743796400",
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
