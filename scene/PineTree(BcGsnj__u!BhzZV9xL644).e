13
4823248273409
405080504266670 1761863339827244600
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 13.8385066986083984,
    "Y": -10.2186651229858398
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405079073661787:1761863339493912500",
  "next_sibling": "405100603592857:1761863344510408300",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405080504639824:1761863339827330600",
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
  "aoid": "405080504795355:1761863339827366800",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405080504639824:1761863339827330600",
    "DefaultRenderer": "405080504881398:1761863339827386800",
    "DepletedRenderer": "405080504853921:1761863339827380400"
  }
},
{
  "cid": 5,
  "aoid": "405080504818446:1761863339827372200",
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
