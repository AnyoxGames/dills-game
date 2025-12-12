13
4243427688449
404983293587500 1761863317177055600
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -7.2414236068725586,
    "Y": -11.6938333511352539
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404980503802924:1761863316527033200",
  "next_sibling": "404989374287415:1761863318593864900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404983293845629:1761863317177115000",
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
  "aoid": "404983293970544:1761863317177144000",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404983293845629:1761863317177115000",
    "DefaultRenderer": "404983294019306:1761863317177155400",
    "DepletedRenderer": "404983294004127:1761863317177151800"
  }
},
{
  "cid": 5,
  "aoid": "404983293983487:1761863317177147100",
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
