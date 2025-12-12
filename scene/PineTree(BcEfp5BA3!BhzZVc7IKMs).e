13
3749506449409
404929145737271 1761863304560550700
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -16.0069122314453125,
    "Y": -9.9834938049316406
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404923780867425:1761863303310530000",
  "next_sibling": "404934724423239:1761863305860389800",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404929146088151:1761863304560631300",
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
  "aoid": "404929146240844:1761863304560666900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404929146088151:1761863304560631300",
    "DefaultRenderer": "404929146318674:1761863304560685100",
    "DepletedRenderer": "404929146291283:1761863304560678700"
  }
},
{
  "cid": 5,
  "aoid": "404929146260323:1761863304560671500",
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
